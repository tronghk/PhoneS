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
        private readonly ICustomerService _customerService;
        private readonly IBillService _billService;
        private readonly IProductBillService _productBillService;

        public UCartController(ILogger<UCartController> logger, ApplicationDbContext db, IProductService productService,
            ICartService cartService, IVoucherService voucherService, ICustomerService customerService, IBillService billService, IProductBillService productBillService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _cartService = cartService;
            _voucherService = voucherService;
            _customerService = customerService;
            _billService = billService;
            _productBillService = productBillService;
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

        public async Task<IActionResult> Delete(int cartid)
        {
            await _cartService.DeleteById(cartid);
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

        [HttpGet]
        public async Task<IActionResult> HistoryBill(int id)
        {

            Customer cu = _customerService.GetByCustomerUserId(id+"");
            if (cu != null)
            {
               var list = _billService.searchAsync(cu.CustomerID).Select(entity => new BillModel
               {
                   BillID = entity.BillID,
                   DateCreated = entity.DateCreated,
                   MoneySum = entity.MoneySum,
                   EmployeeID = entity.EmployeeID,
                   Voucher = entity.VoucherID
               }).ToList();

                foreach (var item in list)
                {
                    var value = _voucherService.GetByVoucherId(int.Parse(item.Voucher + ""));
                    if (value != null)
                        item.Voucher = value.PriceSale;
                    else item.Voucher = 0;
                }

                foreach(var item in list)
                {
                    var listP = _productBillService.GetByProductBillId(item.BillID);
                    var listRe = new List<ProductModel>();
                    foreach(var value in listP)
                    {
                        var product = _productService.GetProductById(value.ProductID);
                        listRe.Add(new ProductModel
                        {
                            BillId = value.BillID,
                            ProductName = product.ProductName,
                            Price = product.Price
                            ,Quantity = value.Quantity,
                            Image = product.Picture

                        });
                    }
                    item.Products = listRe;
                    listRe = new List<ProductModel>();
                    
                }


                ViewBag.list = list;


                return View();
            }
           
            return View();
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
