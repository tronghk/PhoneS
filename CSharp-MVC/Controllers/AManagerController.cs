using CSharp_MVC.Models;
using CSharp_MVC.Request;
using Microsoft.AspNetCore.Mvc;
using Service;
using Entity;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class AManagerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductInfoService _productInfoService;
        private readonly IUnityService _unityService;
        private readonly ILogger<AManagerController> _logger;
        private IWebHostEnvironment _environment;
        public AManagerController(ILogger<AManagerController> logger, IProductService productService,
            IProductCategoryService productCategoryService, IProductInfoService productInfoService, IUnityService unityService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _logger = logger;
            _productInfoService = productInfoService;
            _unityService = unityService;
            _environment = environment;
        }
        public IActionResult Index(string result, string message)
        {
            var listProduct = _productService.GetAll().Select(entity => new ProductCate
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = (float)entity.Price,
                Quantity = (int)entity.Quantity,
                Category = entity.ProdCateID,
            }).ToList();

            var listCategory = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            var listProductView = new List<ProductManagerVm>();
            foreach (var product in listProduct)
            {
                foreach (var category in listCategory) {
                    if (product.Category == category.ProdCateID)
                    {
                        ProductManagerVm pro = new ProductManagerVm();
                        pro.ProductID = product.ProductID;
                        pro.ProductName = product.ProductName;
                        pro.Description = product.Description;
                        pro.Picture = product.Picture;
                        pro.Price = product.Price;
                        pro.Quantity = product.Quantity;
                        pro.Category = category.ProdCateName;
                        listProductView.Add(pro); 
                        
                    }
                }
            }
            if (result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewBag.listProduct = listProductView;
            ViewBag.lengthList = listProductView.Count();
            ViewBag.indexPage = 0;
            return View();
        }

        [Route("AManager/GetPage/{id:int}")]
        public async Task<IActionResult> GetPage(int? id)
        {
            var listProduct = _productService.GetAll().Select(entity => new ProductCate
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = (float)entity.Price,
                Quantity = (int)entity.Quantity,
                Category = entity.ProdCateID,
            }).ToList();

            var listCategory = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            var listProductView = new List<ProductManagerVm>();
            foreach (var product in listProduct)
            {
                foreach (var category in listCategory)
                {
                    if (product.Category == category.ProdCateID)
                    {
                        ProductManagerVm pro = new ProductManagerVm();
                        pro.ProductID = product.ProductID;
                        pro.ProductName = product.ProductName;
                        pro.Description = product.Description;
                        pro.Picture = product.Picture;
                        pro.Price = product.Price;
                        pro.Quantity = product.Quantity;
                        pro.Category = category.ProdCateName;
                        listProductView.Add(pro);

                    }
                }
            }
            ViewBag.listProduct = listProductView;
            ViewBag.lengthList = listProductView.Count();
            ViewBag.indexPage = id+6;
            return View();
        }
        public IActionResult Create()
        {
            var listCategory = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            var length = _productService.GetCount();
            ViewData["listCate"] = listCategory;
            ViewData["idProduct"] = length+1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductAll request)
        {
            IFormFile file = request.Picture;


            var fileName = file.FileName;
            DateTime dt = DateTime.Now; // Or whatever
            string s = dt.ToString("yyyyMMddHHmmss");
            string newName = "IMG-" + s + fileName.Substring(fileName.Length - 4);
            if (fileName.Length > 0)
            {

                string path = Path.Combine(_environment.ContentRootPath, "StaticFile", "Images", newName);

                using (var st = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(st);
                }


            }




            string result = "empty";
            string message = "";
            int idCategory = _productCategoryService.GetByProductCategoryName(Request.Form["Category"].ToString()).ProdCateID;
            string cate = Request.Form["Description"].ToString();
            if (!ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = request.ProductName,
                    Description = cate,
                    Picture = newName,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    ProdCateID = idCategory

                };
                var productInf = new ProductInfo
                {
                    ProductID = request.ProductID,
                    BackCam = request.BackCam,
                    Battery = request.Battery,
                    Chip = request.Chip,
                    FrontCam = request.FrontCam,
                    OS = request.OS,
                    Ram = request.Ram,
                    Screen = request.Screen,
                    SIM = request.SIM,
                    Storage = request.Storage,

                };
                result = await _productService.CreateAsync(product);
                message = "Thêm sản phẩm" + _unityService.getMessage(result);

                await _productInfoService.CreateAsync(productInf);
            }

            return RedirectToAction("Index", "AProductManager", new { @id = 0, @result = result, @message = message });
        }
        [HttpGet]
        [Route("AManager/Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var listCategory = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();

            var product = _productService.GetByProductId(id);
            var proInf = _productInfoService.GetByProductInfoId(id);
            var productAll = new ProductAll
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                nameFile = product.Picture,
                Price = product.Price,
                Quantity = product.Quantity,
                Description = product.Description,
                Category = product.ProdCateID,
                BackCam = proInf.BackCam,
                FrontCam = proInf.FrontCam,
                OS = proInf.OS,
                Screen = proInf.Screen,
                Battery = proInf.Battery,
                Chip = proInf.Chip,
                Ram = proInf.Ram,
                SIM = proInf.SIM,
                Storage = proInf.Storage,

            };
            if (product != null)
            {
                var category = _productCategoryService.GetByProductCategoryId(product.ProdCateID);
                ViewData["cate"] = category.ProdCateName;
                ViewData["product"] = productAll;
                ViewData["listCate"] = listCategory;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct([FromForm] ProductAll request)
        {
            string result = "empty";
            string message = "";
            int idCategory = _productCategoryService.GetByProductCategoryName(Request.Form["Category"].ToString()).ProdCateID;
            string cate = Request.Form["Description"].ToString();

            IFormFile file = request.Picture;


            var fileName = file.FileName;
            DateTime dt = DateTime.Now; // Or whatever
            string s = dt.ToString("yyyyMMddHHmmss");
            string newName = "IMG-" + s + fileName.Substring(fileName.Length - 4);
            if (fileName.Length > 0)
            {

                string path = Path.Combine(_environment.ContentRootPath, "StaticFile", "Images", newName);

                using (var st = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(st);
                }


            }

            if (file == null)
            {

                var pr = _productService.GetByProductId(request.ProductID);
                newName = pr.Picture;
            }

            if (!ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductID = request.ProductID,
                    ProductName = request.ProductName,
                    Description = cate,
                    Picture = newName,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    ProdCateID = idCategory

                };
                var productInf = new ProductInfo
                {
                    ProductID = request.ProductID,
                    BackCam = request.BackCam,
                    Battery = request.Battery,
                    Chip = request.Chip,
                    FrontCam = request.FrontCam,
                    OS = request.OS,
                    Ram = request.Ram,
                    Screen = request.Screen,
                    SIM = request.SIM,
                    Storage = request.Storage,

                };
                result = await _productService.UpdateAsync(product);
                message = "Sửa sản phẩm" + _unityService.getMessage(result);
                await _productInfoService.UpdateAsync(productInf);
            }

            return RedirectToAction("Index", "AProductManager", new { @id = 0, @result = result, @message = message });

        }

        [Route("AManager/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productInfoService.DeleteById(id);
            string result = await _productService.DeleteById(id);
            string message = "Xóa sản phẩm" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AManager", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if(search == "") {
                return RedirectToAction("Index", "AManager");
            }
            var listProduct = _productService.searchProduct(search).Select(entity => new ProductCate
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = (float)entity.Price,
                Quantity = (int)entity.Quantity,
                Category = entity.ProdCateID,
            }).ToList();
            if(listProduct.Count == 0) {
                return RedirectToAction("Index", "AManager");
            }
            var listCategory = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
            }).ToList();
            var listProductView = new List<ProductManagerVm>();
            int i = 0;
            foreach (var product in listProduct)
            {
                foreach (var category in listCategory)
                {
                    if (product.Category == category.ProdCateID)
                    {
                        ProductManagerVm pro = new ProductManagerVm();
                        pro.ProductID = product.ProductID;
                        pro.ProductName = product.ProductName;
                        pro.Description = product.Description;
                        pro.Picture = product.Picture;
                        pro.Price = product.Price;
                        pro.Quantity = product.Quantity;
                        pro.Category = category.ProdCateName;
                        listProductView.Add(pro);

                    }
                }
                if (i == 5)
                    break;
                i++;
            }
            ViewBag.listProduct = listProductView;
            ViewBag.lengthList = listProductView.Count();
            ViewBag.indexPage = 0;
            return View("Index"); ;
        }
    }
}
