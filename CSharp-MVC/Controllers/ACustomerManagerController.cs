using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class ACustomerManagerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IUnityService _unityService;
        private readonly ILogger<ACustomerManagerController> _logger;

        public ACustomerManagerController(ICustomerService customerService, IUserService userService, ILogger<ACustomerManagerController> logger,IUnityService unityService)
        {
            _customerService = customerService;
            _userService = userService;
            _unityService = unityService;
            _logger = logger;
        }


         [Route("ACustomerManager/Index/{id:int}")]
        public IActionResult Index(int id)
        {
            var listCustomer = _customerService.GetAll().Select(entity => new CustomerVm {
                CustomerID = entity.CustomerID,
                Nationality = entity.Nationality,
                FullName = entity.FullName,
                Phone = entity.Phone,
                Email = entity.Email,
                Address = entity.Address,
                 }).ToList();
            ViewData["listCustomer"] = listCustomer;
            ViewData["indexPage"] = id;
            return View();
        }

        [Route("ACustomerManager/Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var cu = _customerService.GetByCustomerId(id);
            CustomerVm c = new CustomerVm();
            c.CustomerID = cu.CustomerID;
            c.Nationality = cu.Nationality;
            c.FullName = cu.FullName;
            c.Phone = cu.Phone;
            c.Email = cu.Email;
            c.Address = cu.Address;
            ViewData["customer"] = c;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer([FromForm] CustomerVm request)
        {
            
            string nationality = Request.Form["Nationality"].ToString();
            string role = _customerService.GetByCustomerId(request.CustomerID).Account;
            var customer = new Customer {
                CustomerID = request.CustomerID,
                Nationality = nationality,
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                Account = role,
            };
             
            string result = await _customerService.UpdateAsync(customer);
            string message = "Sửa khách hàng" + _unityService.getMessage(result);
            return RedirectToAction("Index", "ACustomerManager", new { @id = 0, @result = result, @message = message });

        }


        [Route("ACustomerManager/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            string result = "empty";
            string message = "";

            if (!ModelState.IsValid)
            {
                var em = _customerService.GetByCustomerId(id);
                if (em != null)
                {
                    var user = _userService.GetByUserId(int.Parse(em.Account));

                    result =  await _customerService.DeleteById(id);
                    await _userService.DeleteById(user.UserID);

                }

               
            }
            message = "Xóa khách hàng" + _unityService.getMessage(result);
            return RedirectToAction("Index", "ACustomerManager", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index", "ACustomerManager");
            }
            var listCustomer = _customerService.search(search).Select(entity => new CustomerVm
            {
                CustomerID = entity.CustomerID,
                Nationality = entity.Nationality,
                FullName = entity.FullName,
                Phone = entity.Phone,
                Email = entity.Email,
                Address = entity.Address,
            }).ToList();
            ViewData["listCustomer"] = listCustomer;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }


    }
}
