using Microsoft.AspNetCore.Mvc;

namespace CSharp_MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
