using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class AProductPromotionController : Controller
    {
        private readonly IProductSaleService _productSaleService;
        private readonly IProductService _productService;
        private readonly IUnityService _unityService;

        private readonly ILogger<AMProductCategoryController> _logger;

        public AProductPromotionController(IProductSaleService productSaleService, IProductService productService, ILogger<AMProductCategoryController> logger, IUnityService unityService)
        {
            _productSaleService = productSaleService;
            _productService = productService;
            _logger = logger;
            _unityService = unityService;
        }

        [Route("AProductPromotion/Index/{id:int}")]
        public IActionResult Index(int id,string result, string message)
        {
            var listPromotion = _productSaleService.GetAll().Select(entity => new ProductSaleVm
            {
               ProdSaleID = entity.ProdSaleID,
               ProductID = entity.ProductID,
               DateStarted = entity.DateStarted,
               DateEnded = entity.DateEnded,
               PercentSale = entity.PercentSale,
               PriceSale = entity.PriceSale,

            }).ToList();
            foreach (var item in listPromotion)
            {
                var name = _productService.GetByProductId(item.ProductID).ProductName;
                item.ProductName = name;
            }
            if (result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewData["listPromotion"] = listPromotion;
            ViewData["indexPage"] = id;
            return View();
        }


        [Route("AProductPromotion/Create")]
        public IActionResult Create()
        {
            var listPromotion = _productSaleService.GetAll().Select(entity => new ProductSaleVm
            {
                ProdSaleID = entity.ProdSaleID,
                ProductID = entity.ProductID,
                DateStarted = entity.DateStarted,
                DateEnded = entity.DateEnded,
                PercentSale = entity.PercentSale,
                PriceSale = entity.PriceSale,

            }).ToList();
            var listProduct = _productService.GetAll().Select(entity => new ProductVm
            {
                ProductName = entity.ProductName,

            }).ToList();
            int max = listPromotion[0].ProdSaleID;
            foreach (var item in listPromotion)
            {
                if (max < item.ProdSaleID)
                    max = item.ProdSaleID;
            }
            ViewData["listProduct"] = listProduct;
            ViewData["id"] = max + 1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromForm] ProductSaleVm request)
        {

            var p = new ProductSale
            {
                DateStarted = request.DateStarted,
                DateEnded = request.DateEnded,
                PercentSale = request.PercentSale,
                

            };
            string name = Request.Form["nameProduct"].ToString();
            var product = _productService.GetByProductName(name);
            p.ProductID = product.ProductID;
            p.PriceSale = product.Price* p.PercentSale/100;
            string result= await _productSaleService.CreateAsync(p);
            string message = "Thêm khuyến mãi" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AProductPromotion", new { @id = 0, @result = result, @message = message });
        }

      

        [Route("AProductPromotion/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {


            string result =await _productSaleService.DeleteById(id);
            string message = "Xóa khuyến mãi" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AProductPromotion", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index");
            }
            var listPromotion = _productSaleService.search(search).Select(entity => new ProductSaleVm
            {
                ProdSaleID = entity.ProdSaleID,
                ProductID = entity.ProductID,
                DateStarted = entity.DateStarted,
                DateEnded = entity.DateEnded,
                PercentSale = entity.PercentSale,
                PriceSale = entity.PriceSale,

            }).ToList();
            foreach (var item in listPromotion)
            {
                var name = _productService.GetByProductId(item.ProductID).ProductName;
                item.ProductName = name;
            }
            ViewData["listPromotion"] = listPromotion;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }
    }
}
