using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;
using System.Data;

namespace CSharp_MVC.Controllers
{
    public class AVoucherManagerController : Controller
    {
        private readonly IVoucherService _voucherService;
        private readonly IProductService _productService;
        private readonly IUnityService _unityService;

        private readonly ILogger<AVoucherManagerController> _logger;

        public AVoucherManagerController(IVoucherService voucherService, IProductService productService, ILogger<AVoucherManagerController> logger, IUnityService unityService)
        {
            _voucherService = voucherService;
            _productService = productService;
            _logger = logger;
            _unityService = unityService;
        }

        [Route("AVoucherManager/Index/{id:int}")]
        public IActionResult Index(int id,string result,string message)
        {
            var listVoucher = _voucherService.GetAll().Select(entity => new VoucherVm
            {
                VoucherID = entity.VoucherID,
                DateStarted = entity.DateStarted,
                DateEnded = entity.DateEnded,
                PercentSale = entity.PercentSale,
                PriceSale = entity.PriceSale,
                UseTimess = entity.UseTimess

            }).ToList();
            if (result != null)
            {
                ViewData["result"] = result; ViewData["message"] = message;
            }
            ViewData["listVoucher"] = listVoucher;
            ViewData["indexPage"] = id;
            return View();
        }


        [Route("AVoucherManager/Create")]
        public IActionResult Create()
        {
            var listVoucher = _voucherService.GetAll().Select(entity => new VoucherVm
            {
                VoucherID = entity.VoucherID,
                DateStarted = entity.DateStarted,
                DateEnded = entity.DateEnded,
                PercentSale = entity.PercentSale,
                PriceSale = entity.PriceSale,

            }).ToList();
            int max = listVoucher[0].VoucherID;
            foreach (var item in listVoucher)
            {
                if (max < item.VoucherID)
                    max = item.VoucherID;
            }
            ViewData["id"] = max + 1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVoucher([FromForm] VoucherVm request)
        {

            var p = new Voucher
            {
                DateStarted = request.DateStarted,
                DateEnded = request.DateEnded,
                PercentSale = request.PercentSale,
                UseTimess = request.UseTimess

            };
            p.PriceSale = 0;
            string result = await _voucherService.CreateAsync(p);
            string message = "Thêm Voucher" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AVoucherManager", new { @id = 0, @result = result, @message = message });
        }



        [Route("AVoucherManager/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {


            string result= await _voucherService.DeleteById(id);
            string message = "Xóa Voucher" + _unityService.getMessage(result);
            return RedirectToAction("Index", "AVoucherManager", new { @id = 0, @result = result, @message = message });

        }

        [HttpPost]
        public IActionResult Search()
        {
            string search = Request.Form["search"].ToString();
            if (search == "")
            {
                return RedirectToAction("Index");
            }
            var listVoucher = _voucherService.search(search).Select(entity => new VoucherVm
            {
                VoucherID = entity.VoucherID,
                DateStarted = entity.DateStarted,
                DateEnded = entity.DateEnded,
                PercentSale = entity.PercentSale,
                PriceSale = entity.PriceSale,
                UseTimess = entity.UseTimess

            }).ToList();
            ViewData["listVoucher"] = listVoucher;
            ViewData["indexPage"] = 0;
            return View("Index"); ;
        }
    }
}
