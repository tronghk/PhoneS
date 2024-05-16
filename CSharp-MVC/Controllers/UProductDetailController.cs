using CSharp_MVC.Models;
using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CSharp_MVC.Controllers
{
    public class UProductDetailController : Controller
    {
        private readonly ILogger<UProductDetailController> _logger;
        private readonly ApplicationDbContext _db;

        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductImageService _productImageService;
        private readonly IProductInfoService _productInfoService;
        private readonly ICartService _cartService;

        public UProductDetailController(ILogger<UProductDetailController> logger, ApplicationDbContext db, IProductService productService, IProductCategoryService productCategoryService, IProductImageService productImageService, IProductInfoService productInfoService, ICartService cartService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productImageService = productImageService;
            _productInfoService = productInfoService;
            _cartService = cartService;
        }

        public IActionResult Index(int id)
        {
            var product = _productService.GetByProductId(id);
            var category = _productCategoryService.GetByProductCategoryId(product.ProdCateID);
            var productinfo = _productInfoService.GetByProductInfoId(id);
            var images = _productImageService.GetAllByID(id).Select(i => new ProductImageVm
            {
                ProductID = i.ProductID,
                Name = i.Name,
                ImageLink = i.ImageLink
            });

            var carts = _cartService.GetAll().Select(entity => new CartVm
            {
                CartID = entity.CartID,
                Quantity = entity.Quantity,
                UserID = entity.UserID,
                ProductID = entity.ProductID
            }).ToList();

            var products = _productService.GetAll().Select(entity => new ProductVm
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = entity.Price,
                Quantity = entity.Quantity,
                ProdCateID = entity.ProdCateID,
                ProdCateName = "null"
            }).ToList();

            ProductDetailVm productDetailVm = new ProductDetailVm();
            productDetailVm.ProductID = product.ProductID;
            productDetailVm.ProductName = product.ProductName;
            productDetailVm.Price = product.Price;
            productDetailVm.Picture = product.Picture;
            productDetailVm.Quantity = product.Quantity;
            productDetailVm.Description = product.Description;
            productDetailVm.ProdCateID = category.ProdCateID;
            productDetailVm.ProdCateName = category.ProdCateName;
            productDetailVm.Imgs = images.ToList();
            productDetailVm.Screen = productinfo.Screen;
            productDetailVm.OS = productinfo.OS;
            productDetailVm.FrontCam = productinfo.FrontCam;
            productDetailVm.BackCam = productinfo.BackCam;
            productDetailVm.Chip = productinfo.Chip;
            productDetailVm.Ram = productinfo.Ram;
            productDetailVm.Storage = productinfo.Storage;
            productDetailVm.SIM = productinfo.SIM;
            productDetailVm.Battery = productinfo.Battery;
            productDetailVm.Cart = carts;
            productDetailVm.Products = products;
            return View(productDetailVm);
        }


    }
}
