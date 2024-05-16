using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class AMProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IUnityService _unityService;
        private readonly ILogger<AMProductCategoryController> _logger;

        public AMProductCategoryController(IProductCategoryService productCategoryService, ILogger<AMProductCategoryController> logger, IUnityService unityService)
        {
            _productCategoryService = productCategoryService;
            _logger = logger;
            _unityService = unityService;
        }

        [Route("AMProductCategory/Index/{id:int}")]
        public IActionResult Index(int id,string result,string message)
        {
            var listCate = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            if (result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewData["listCate"] = listCate;
            ViewData["indexPage"] = id;
            return View();
        }

        [Route("AMProductCategory/Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var cu = _productCategoryService.GetByProductCategoryId(id);
            ProductCategoryVm p = new ProductCategoryVm {
                ProdCateID = cu.ProdCateID,
                ProdCateName = cu.ProdCateName,
            };

            ViewData["cate"] = p;

            return View();
        }

        [Route("AMProductCategory/Create")]
        public IActionResult Create()
        {
            var listCate = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            int max = listCate[0].ProdCateID;
            foreach (var item in listCate)
            {
                if (max < item.ProdCateID)
                    max = item.ProdCateID;
            }
            ViewData["id"] = max + 1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] ProductCategoryVm request)
        {

            var p = new ProductCategory
            {
                ProdCateName = request.ProdCateName,
            };
            
            string result = await _productCategoryService.CreateAsync(p);
            string message = "Thêm loại" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AMProductCategory", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory([FromForm] ProductCategoryVm request)
        {

            var p = new ProductCategory
            {
                ProdCateID = request.ProdCateID,
                ProdCateName = request.ProdCateName,
            };
            
            string result = await _productCategoryService.UpdateAsync(p);
            string message = "Sửa loại" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AMProductCategory", new { @id = 0, @result = result, @message = message });
        }


        [Route("AMProductCategory/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await _productCategoryService.DeleteById(id);
            string message = "Xóa loại" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AMProductCategory", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index");
            }
            var listCate = _productCategoryService.search(search).Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            ViewData["listCate"] = listCate;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }
    }
}
