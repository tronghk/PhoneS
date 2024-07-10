using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using BCrypt.Net;

namespace CSharp_MVC.Controllers
{
    public class USignupController : Controller
    {
        private readonly IUserService _userService;
        public USignupController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("customer");
            if (session != null)
            {
                return RedirectToAction("Index", "UHome");
            }

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();  
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            return RedirectToAction("Index", "USignup");
        }
        [HttpPost]
        public async Task<IActionResult> Index(Signup user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            string password = user.Password;
          //  string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var newuser = new User()
            {
                Account = user.Account,
                Password = password
            };
            var newcustomer = new Customer()
            {
                FullName = user.FullName,
                Nationality = user.Nationality,
                Phone = user.Phone,
                
                Address= user.Address,
                Email = user.Account
            };
            var result = await _userService.CreateUserAccount(newuser, newcustomer);
            if (result == false)
            {
                ModelState.AddModelError("", "Account already existed !");
                return View();
            }
            TempData["signup"] = "Đăng ký thành công";
            return RedirectToAction("Index", "USignin");

        }
    }
}
