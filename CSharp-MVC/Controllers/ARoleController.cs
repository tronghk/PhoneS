using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;

namespace CSharp_MVC.Controllers
{
    public class ARoleController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IUnityService _unityService;

        private readonly ILogger<ARoleController> _logger;

       
        public ARoleController(IEmployeeService employeeService, ICustomerService customerService,
            IUserService userService, ILogger<ARoleController> logger, IRoleService roleService, IUnityService unityService)
        {
            _employeeService = employeeService;
            _customerService = customerService;
            _userService = userService;
            _roleService = roleService;
            _unityService = unityService;
            _logger = logger;
        }



         [Route("ARole/Index/{id:int}")]
        public IActionResult Index(int id, string result,string message)
        {
            var listUser = _userService.GetAll().Select(entity => new UserVm
            {
                UserID = entity.UserID,
                Account = entity.Account,
                Password = entity.Password,
                RoleId = entity.RoleId,
            }).ToList();


            var listRole = new List<RoleToUserModelView>();

            foreach (var item in listUser)
            {
                var u = new RoleToUserModelView();
                var r =  _roleService.GetByRoleId(item.RoleId);
                u.idRole = item.RoleId;
                u.user = item.Account;
                u.description = r.RoleDescription;
                u.name = r.RoleName;
                listRole.Add(u);
            }
            if(result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewData["listRole"] = listRole;
            ViewData["indexPage"] = id;
            return View();
        }

        public IActionResult Edit(string name)
        {
            var cu = _userService.GetByUserAccount(name);
            var role = _roleService.GetByRoleId(cu.RoleId);
            var u = new RoleToUserModelView { user = cu.Account,name=role.RoleName };
            var listRole = _roleService.GetAll().Select(entity => new RoleVm
            {
                RoleName = entity.RoleName,
            }).ToList();
            ViewData["user"] = u;
            ViewData["listRole"] = listRole;
            return View();
        }

        [Route("ARole/Create")]
        public IActionResult Create()
        {
            var listRole = _roleService.GetAll().Select(entity => new RoleToUserModelView
            {
               idRole = entity.RoleId,
            }).ToList();
            int max = listRole[0].idRole;
            foreach (var item in listRole)
            {
                if (max < item.idRole)
                    max = item.idRole;
            }
            ViewData["id"] = max + 1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromForm] RoleToUserModelView request)
        {
           
            var role = new Role { 
                RoleName = request.name,
                RoleDescription = request.description,
            
            };

            string result = await _roleService.CreateAsync(role);
            string message = "Thêm quyền" + _unityService.getMessage(result);
            return RedirectToAction("Index", "ARole", new { @id = 0, @result = result, @message = message });
        }

        [HttpPost]
        public async Task<IActionResult> EditRole([FromForm] RoleToUserModelView request)
        {

            string role = Request.Form["role"].ToString();
            var r = _roleService.GetByRoleName(role);
            var user = _userService.GetByUserAccount(request.user);
            user.RoleId = r.RoleId;
            string result = await _userService.UpdateAsync(user);
            string message = "Sửa quyền" +  _unityService.getMessage(result);
            return RedirectToAction("Index", "ARole", new { @id = 0, @result = result, @message = message });
        }



        public  IActionResult Delete()
        {


            var listRole = _roleService.GetAll().Select(entity => new RoleVm
            {
                
                RoleName = entity.RoleName,
                RoleDescription = entity.RoleDescription,

            }).ToList();
            ViewData["listRole"] = listRole;

            return View();
        }

        public async Task<IActionResult> DeleteRole(string name)
        {
            string result = "emplty";
            if (name != null)
            {
                var role = _roleService.GetByRoleName(name);
                result = await _roleService.DeleteAsSycn(role);
                ViewData["result"] = result;
                ViewData["message"] = _unityService.getMessage(result);
                var listRole = _roleService.GetAll().Select(entity => new RoleVm
                {

                    RoleName = entity.RoleName,
                    RoleDescription = entity.RoleDescription,

                }).ToList();
                ViewData["listRole"] = listRole;
                return View("Delete");
            }

            return RedirectToAction("Delete", "ARole");
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
                RoleId = entity.RoleId,
            }).ToList();


            var listRole = new List<RoleToUserModelView>();

            foreach (var item in listUser)
            {
                var u = new RoleToUserModelView();
                var r = _roleService.GetByRoleId(item.RoleId);
                u.idRole = item.RoleId;
                u.user = item.Account;
                u.description = r.RoleDescription;
                u.name = r.RoleName;
                listRole.Add(u);
            }
            ViewData["listRole"] = listRole;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }

    }
}
