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
        private readonly IVoucherService _voucherService;

        public UCartController(ILogger<UCartController> logger, ApplicationDbContext db, IProductService productService, ICartService cartService, IVoucherService voucherService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _cartService = cartService;
            _voucherService = voucherService;
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

            ViewBag.endSum = -1;
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

        [HttpGet("UCart/GetValueCode")]
        public IActionResult GetValueCode(string code) 
        {

            var result = _voucherService.GetByVoucherCode(code);
            
            if(result != null)
            {
                if(result.DateEnded > DateTime.Now && result.DateStarted < DateTime.Now && result.UseTimess > 0)
                {

                    ViewBag.abc = result.VoucherID;
                    var model = new VoucherCodeModel
                    {
                        Id = result.VoucherID,
                        Price = result.PriceSale,
                    };
                    return Json(model);
                }
            }
             return NotFound();

        }
    }
}
