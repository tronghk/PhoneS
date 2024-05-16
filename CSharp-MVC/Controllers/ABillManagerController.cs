using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class ABillManagerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBillService _billService;
        private readonly IProductBillService _productBillService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly IVoucherService _voucherService;
        private readonly IProductSaleService _productSaleService;
        private readonly ILogger<AManagerController> _logger;

        public ABillManagerController(IProductService productService, IBillService billService, IProductBillService productBillService, IEmployeeService employeeService, ICustomerService customerService, IVoucherService voucherService, IProductSaleService productSaleService, ILogger<AManagerController> logger)
        {
            _productService = productService;
            _billService = billService;
            _productBillService = productBillService;
            _employeeService = employeeService;
            _customerService = customerService;
            _voucherService = voucherService;
            _productSaleService = productSaleService;
            _logger = logger;
        }

        [Route("ABillManager/Index/{id:int}")]
        public IActionResult Index(int id)
        {

            var listBill = _billService.GetAll().Select(entity => new BillModelView
            {
                BillID = entity.BillID,
                DateCreated = entity.DateCreated,
                MoneySum = entity.MoneySum,
                VoucherID = entity.VoucherID,
                employee = entity.EmployeeID+"",
                customer =  entity.CustomerID+"",
            }).ToList();
            
            
            foreach(var item in listBill)
            {
                item.customer = _customerService.GetByCustomerId(int.Parse(item.customer)).FullName;
                item.employee = _employeeService.GetByEmployeeId(int.Parse(item.employee)).FullName;
            }
            ViewData["listBill"] = listBill;
            ViewData["indexPage"] = id;
            return View();
        }
        [Route("ABillManager/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var bill = _billService.GetByBillId(id);
            var listDetails = _productBillService.GetByProductBillId(id).Select(entity => new DetailsBillModel
            {
               name = entity.ProductID+"",
               quantity = entity.Quantity,

            }).ToList();

            float sum = _billService.GetByBillId(id).MoneySum;
            float voucher = _voucherService.GetByVoucherId(bill.VoucherID).PriceSale;
            foreach(var item in listDetails)
            {
                Product p = _productService.GetByProductId(int.Parse(item.name));

                item.sumMoney = p.Price * item.quantity;
                item.name = p.ProductName;
                item.price = p.Price;
                item.sale = 0;
            }
            ViewData["sumBill"] = sum;
            ViewData["listDetails"] = listDetails;
            ViewData["voucher"] = voucher;
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index", "ABillManager");
            }
            var listBill = _billService.search(search).Select(entity => new BillModelView
            {
                BillID = entity.BillID,
                DateCreated = entity.DateCreated,
                MoneySum = entity.MoneySum,
                VoucherID = entity.VoucherID,
                employee = entity.EmployeeID + "",
                customer = entity.CustomerID + "",
            }).ToList();
            foreach (var item in listBill)
            {
                item.customer = _customerService.GetByCustomerId(int.Parse(item.customer)).FullName;
                item.employee = _employeeService.GetByEmployeeId(int.Parse(item.employee)).FullName;
            }
            ViewData["listBill"] = listBill;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }
    }
}
