using CSharp_MVC.Models;
using CSharp_MVC.Request;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using Service.implementation;
using System.Runtime.ConstrainedExecution;

namespace CSharp_MVC.Controllers
{
    public class USigninController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleSerivce;
        public USigninController(IUserService userService, IRoleService roleSerivce)
        {
            _userService = userService;
            _roleSerivce = roleSerivce;
        }
        public IActionResult Index()
        {
            string message = TempData["signup"] as string;

            if (message != null)
            {
                TempData["Message"] = message;
            }


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Signin request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            string Account = request.Account;
            string Password = request.Password;
            var user = _userService.GetByUserAccount(Account, Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                return View();
            }
            if(user.Account != Account || user.Password != Password)
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                return View();
            }
           
            var customerInformation = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString("customer", customerInformation);
            var role = _roleSerivce.GetByRoleId(user.RoleId);
            if (role.RoleName == "Admin")
            {
                return RedirectToAction("Index", "AManager");
            }
            return RedirectToAction("Index","UHome");
        }
        [HttpPost("logout")]
        public IActionResult Signout()
        {
            HttpContext.Session.Remove("customer");
            return RedirectToAction("Index", "UHome");
        }
    }
}
