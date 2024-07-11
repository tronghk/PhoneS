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

        public UPaymentController(ILogger<UPaymentController> logger, ApplicationDbContext db, IProductService productService, ICartService cartService, IPaymentService paymentService, ICustomerService customerService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _cartService = cartService;
            _paymentService = paymentService;
            _customerService = customerService;
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

            var user = _customerService.GetAll().Select(entity => new UserPaymentVm
            {
                CustomerID = entity.CustomerID,
                Account = int.Parse(entity.Account)
            }).ToList();

            var uPaymentVm = new UPaymentVm();
            uPaymentVm.Products = products;
            uPaymentVm.Cart = cart;
            uPaymentVm.User = user;

            return View(uPaymentVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(float money, int cusid)
        {
            var bill = new Entity.Bill();
            bill.DateCreated = DateTime.Now;
            bill.MoneySum = money;
            bill.EmployeeID = 4;
            bill.CustomerID = cusid;
            bill.VoucherID = 1;

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
            return RedirectToAction("Index");
        }
    }
}
