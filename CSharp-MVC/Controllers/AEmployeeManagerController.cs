using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class AEmployeeManagerController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IUnityService _unityService;
        private readonly ILogger<AEmployeeManagerController> _logger;

        public AEmployeeManagerController(IEmployeeService employeeService, IUserService userService, ILogger<AEmployeeManagerController> logger, IUnityService unityService)
        {
            _employeeService = employeeService;
            _userService = userService;
            _logger = logger;
            _unityService = unityService;
        }

        [Route("AEmployeeManager/Index/{id:int}")]
        public IActionResult Index(int id,string result,string message)
        {
            var listEmployee = _employeeService.GetAll().Select(entity => new EmployeeVm
            {
                EmployeeID = entity.EmployeeID,
                Nationality = entity.Nationality,
                FullName = entity.FullName,
                Phone = entity.Phone,
                Email = entity.Email,
                CoefSalary = entity.CoefSalary,
                Salary = entity.Salary,
            }).ToList();
            if (result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewData["listEmployee"] = listEmployee;
            ViewData["indexPage"] = id;
            return View();
        }

        [Route("AEmployeeManager/Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var cu = _employeeService.GetByEmployeeId(id);
            EmployeeVm c = new EmployeeVm();
            c.EmployeeID = cu.EmployeeID;
            c.Nationality = cu.Nationality;
            c.FullName = cu.FullName;
            c.Phone = cu.Phone;
            c.Email = cu.Email;
            c.Salary = cu.Salary;
            c.CoefSalary = cu.CoefSalary;
            ViewData["employee"] = c;

            return View();
        }

        [Route("AEmployeeManager/Create")]
        public IActionResult Create()
        {
            var listEmployee = _employeeService.GetAll().Select(entity => new EmployeeVm
            {
                EmployeeID = entity.EmployeeID,
                Nationality = entity.Nationality,
                FullName = entity.FullName,
                Phone = entity.Phone,
                Email = entity.Email,
                CoefSalary = entity.CoefSalary,
                Salary = entity.Salary,
            }).ToList();
            int max = 0;
            if (listEmployee.Count > 0)
            {
                max = listEmployee[0].EmployeeID;
                foreach (var item in listEmployee)
                {
                    if (max < item.EmployeeID)
                        max = item.EmployeeID;
                }
            }
            ViewData["id"] = max + 1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeVm request)
        {

            string nationality = Request.Form["Nationality"].ToString();
            var employee = new Employee
            {
                EmployeeID = request.EmployeeID,
                Nationality = nationality,
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email,
                CoefSalary = request.CoefSalary,
                Salary = request.Salary,
               
            };
            var user = new User
            {
                UserID = request.EmployeeID,
                Account = request.Email,
                Password = "3211",
                RoleId = 3,
            };
            await _userService.CreateAsyncEmployee(user);
            User u = _userService.GetByUserAccount(employee.Email, "3211");
            employee.Account = u.UserID + "";
            string result = await _employeeService.CreateAsync(employee);
            string message = "Thêm nhân viên" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AEmployeeManager", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee([FromForm] EmployeeVm request)
        {

            string nationality = Request.Form["Nationality"].ToString();
            string role = _employeeService.GetByEmployeeId(request.EmployeeID).Account;
            var employee = new Employee
            {
                EmployeeID = request.EmployeeID,
                Nationality = nationality,
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email,
                CoefSalary = request.CoefSalary,
                Salary = request.Salary,
                Account = role,
            };
            
            string result = await _employeeService.UpdateAsync(employee);
            string message = "Sửa nhân viên" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AEmployeeManager", new { @id = 0, @result = result, @message = message });
        }


        [Route("AEmployeeManager/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            string result = "empty";
            string message = "";

            var em =_employeeService.GetByEmployeeId(id);
            
            if (em != null)
            {
                var user = _userService.GetByUserId(int.Parse(em.Account));

                result = await _employeeService.DeleteById(id);
                await _userService.DeleteById(user.UserID);

            }


            message = "Xóa nhân viên" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AEmployeeManager", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index");
            }
            var listEmployee = _employeeService.search(search).Select(entity => new EmployeeVm
            {
                EmployeeID = entity.EmployeeID,
                Nationality = entity.Nationality,
                FullName = entity.FullName,
                Phone = entity.Phone,
                Email = entity.Email,
                CoefSalary = entity.CoefSalary,
                Salary = entity.Salary,
            }).ToList();
            ViewData["listEmployee"] = listEmployee;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }


    }
}
