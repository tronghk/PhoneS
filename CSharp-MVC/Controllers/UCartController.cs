using CSharp_MVC.Models;
using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class UCartController : Controller
    {
        private readonly ILogger<UCartController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public UCartController(ILogger<UCartController> logger, ApplicationDbContext db, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
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

            var cart = _cartService.GetAll().Select(entity => new CartVm
            {
                CartID = entity.CartID,
                Quantity = entity.Quantity,
                UserID = entity.UserID,
                ProductID = entity.ProductID
            }).ToList();

            var uCartVm = new UCartVm();
            uCartVm.Products = products;
            uCartVm.Cart = cart;

            return View(uCartVm);
        }

        public IActionResult Delete(int cartid)
        {
            _cartService.DeleteById(cartid);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatetoCart(int usid, int proid)
        {
            _cartService.AddToCart(usid, proid);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<JsonResult> AddProduct([FromBody] AddProductModel model)
        {

            var result = await _cartService.AddProduct(model.UserId, model.ProductId, model.Quantity);
            var response = new { message = result };
            return Json(response);

        }

        [HttpPost]
        public async Task<JsonResult> RemoveProduct([FromBody] AddProductModel model)
        {

            var result = await _cartService.AddProduct(model.UserId, model.ProductId, model.Quantity);
            var response = new { message = result };
            return Json(response);

        }
    }
}
