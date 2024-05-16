using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_MVC.Controllers
{
    public class UBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
