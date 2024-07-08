using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CSharp_MVC.Controllers
{
    public class UForgotPassController : Controller
    {
        readonly private IEmailSender _emailSender;
        readonly private IUserService _userService;
        public UForgotPassController(IEmailSender emailSender, IUserService user) {
            _userService = user;
        
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            string message = ViewBag.message as string;
             if(message == null)
            {
                return View();
            }
            ViewBag.message = message;
            return View();
        }
        
        public IActionResult editPassword(CodeModel model)
        {
            if(model == null)
            {
                return RedirectToAction("Index", "UForgotPass");
            }else
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> GetCode([FromBody]ForgotModel model)
        {

            string email = model.email;
            // truyền dữ liệu qua model
            //[FromBody] FormDataModel model
            // Xử lý dữ liệu từ form ở đây

            string result =  await _userService.ForgotPassword(email);
            if(result == "error")
            {
                var responses = new { message = "error" };
                return Json(responses);
            }
            var response = new { message = "Vui lòng kiểm tra mail" };
            return Json(response);




        }
        [HttpPost]
        public async Task<IActionResult> Forgot(CodeModel model)
        {
            User us = await _userService.ForgotPassword(model.email, model.code);
            if(us == null)
            {
                ViewBag.message = "Error";
                return RedirectToAction("Index", "UForgotPass");
            }
            else
            {
                return RedirectToAction("editPassword", "UForgotPass", model);
            }
        }
        [HttpPost]
        public async Task<JsonResult> ChangePassword([FromBody]ChangePassword model)
        {
            var result = await _userService.ChangePassword(model.email, model.code, model.password);
            if (result == "success")
            {
                return Json(new { message = "success" });
               
            }
            else
            {
                return Json(new { message = "error" });
            }
        }
    }
}
