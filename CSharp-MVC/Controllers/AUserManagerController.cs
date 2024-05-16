using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class AUserManagerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnityService _unityService;
        private readonly ILogger<AUserManagerController> _logger;

        public AUserManagerController(IUserService userService, ILogger<AUserManagerController> logger, IUnityService unityService)
        {
            _userService = userService;
            _logger = logger;
            _unityService = unityService;
        }

        [Route("AUserManager/Index/{id:int}")]
        public IActionResult Index(int id,string result,string message)
        {
            var listUser = _userService.GetAll().Select(entity => new UserVm
            {
                UserID = entity.UserID,
                Account = entity.Account,
                Password = entity.Password,
            }).ToList();
            if (result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewData["listUser"] = listUser;
            ViewData["indexPage"] = id;
            return View();
        }

        [Route("AUserManager/Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var cu = _userService.GetByUserId(id);
            var user = new UserVm { 
            Account = cu.Account,
            Password = cu.Password,
            UserID = id
            };

            ViewData["user"] = user;

            return View();
        }

        [HttpPost]
        [Route("AUserManager/Edit/{id:int}")]
        public async Task<IActionResult> EditUser([FromForm] UserVm request,int id)
        {

            var us = _userService.GetByUserId(id);
            var user = new User {
                UserID = us.UserID,
                Account = us.Account,
                Password = request.Password,
                RoleId = us.RoleId,

            };

            string result=await _userService.UpdateAsync(user);
            string message = "Sửa tài khoản" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AUserManager", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index");
            }
            var listUser = _userService.search(search).Select(entity => new UserVm
            {
                UserID = entity.UserID,
                Account = entity.Account,
                Password = entity.Password,
            }).ToList();
            ViewData["listUser"] = listUser;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }


    }
}
