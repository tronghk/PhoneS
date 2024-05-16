using Microsoft.AspNetCore.Mvc;
using Service;

namespace CSharp_MVC.Controllers
{
    public class AStatisController : Controller
    {
        private readonly IBillService _billService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public AStatisController(IBillService billService, IProductService productService, ICustomerService customerService)
        {
            _billService = billService;
            _productService = productService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            int lengthCustomer =_customerService.GetAll().ToList().Count;
            int lengthProduct = _productService.GetAll().ToList().Count;
            ViewData["customer"] = lengthCustomer;
            ViewData["product"] =(int)lengthProduct;
            return View();
        }
    }
}
