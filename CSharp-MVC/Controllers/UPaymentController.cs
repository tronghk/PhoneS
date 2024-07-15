using CSharp_MVC.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CSharp_MVC.Controllers
{
    public class UPaymentController : Controller
    {
        private readonly ILogger<UPaymentController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly ICustomerService _customerService;

        private readonly IVoucherService _voucherService;

        public UPaymentController(ILogger<UPaymentController> logger, ApplicationDbContext db, IProductService productService, ICartService cartService
            , IPaymentService paymentService, ICustomerService customerService, IVoucherService voucherService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _cartService = cartService;
            _paymentService = paymentService;
            _customerService = customerService;
            _voucherService = voucherService;
        }


        public IActionResult Index(int id)
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

            var user = _customerService.GetAll().Select(entity => new UserPaymentVm
            {
                CustomerID = entity.CustomerID,
                Account = int.Parse(entity.Account)
            }).ToList();

            var uPaymentVm = new UPaymentVm();
            uPaymentVm.Products = products;
            uPaymentVm.Cart = cart;
            uPaymentVm.User = user;
            if(id!= -1)
            {
              var v =  _voucherService.GetByVoucherId(id);
                ViewBag.price = v.PriceSale;
                ViewBag.voucherId = id;
            }
            else
            {
                ViewBag.price = 0;
                ViewBag.voucherId = -1;
            }
            
            return View(uPaymentVm);
        }
  
        public async Task<IActionResult> CreateOrder(float money, int voucher, int cusid)
        {
            var bill = new Entity.Bill();
            bill.DateCreated = DateTime.Now;
            bill.MoneySum = money;
            bill.EmployeeID = -1;
            bill.CustomerID = cusid;
            bill.VoucherID = voucher;

            var customer = _customerService.GetByCustomerId(cusid);

            var cart = _cartService.GetAll().Select(entity => new CartVm
            {
                CartID = entity.CartID,
                Quantity = entity.Quantity,
                UserID = entity.UserID,
                ProductID = entity.ProductID
            }).ToList();

            var selectioncart = cart.Where(c => c.UserID == int.Parse(customer.Account)).ToList();

            int length = selectioncart.Count;
            int[] IDs = selectioncart.Select(c => c.ProductID).ToArray();

           await _paymentService.CreateAsync(bill, length, IDs);

            await  _paymentService.ClearCart(int.Parse(customer.Account));
            return RedirectToAction("HistoryBill", "UCart", new {id = customer.CustomerID});
        }
        
    }
}
