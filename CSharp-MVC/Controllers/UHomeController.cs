﻿using CSharp_MVC.Models;
using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Service;
using System.Diagnostics;

namespace CSharp_MVC.Controllers
{
    public class UHomeController : Controller
    {
        private readonly ILogger<UHomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICartService _cartService;

        public UHomeController(ILogger<UHomeController> logger, ApplicationDbContext db, IProductService productService, IProductCategoryService productCategoryService, ICartService cartService)
        {
            _logger = logger;
            _db = db;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll().Select(entity => new ProductVm
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = entity.Price,
                Quantity = entity.Quantity,
                ProdCateID = entity.ProdCateID,
                ProdCateName = "null"
            }).ToList();

            var categories = _productCategoryService.GetAll().Select(entity => new ProductCategoryVm
            {
                ProdCateID = entity.ProdCateID,
                ProdCateName = entity.ProdCateName,
                nameImage = entity.linkImage

            }).ToList();

            var productVm = products.Join(
                categories,
                p => p.ProdCateID,
                c => c.ProdCateID,
                (p, c) => new ProductVm
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Picture = p.Picture,
                    Quantity = p.Quantity,
                    Description = p.Description,
                    ProdCateID = c.ProdCateID,
                    ProdCateName = c.ProdCateName
                }
            ).ToList();

            var cart = _cartService.GetAll().Select(entity => new CartVm
            {
                CartID = entity.CartID,
                Quantity = entity.Quantity,
                UserID = entity.UserID,
                ProductID = entity.ProductID
            }).ToList();


            var uHomeVm = new UHomeVm();
            uHomeVm.Products = productVm;
            uHomeVm.Categories = categories;
            uHomeVm.Cart = cart;
           


            // load 5 sản phẩm mới nhất


            // danh sách sản phẩm nổi bật ( duoc mua nhiều nhất)

            var listSortFour = new List<ProductVm>();
            int i = 0;
            foreach(ProductVm value in productVm)
            {
                listSortFour.Add(value);
                i++;
                if(i == 4)
                {
                    break;
                }
            }
            uHomeVm.ListPView = listSortFour;
          

            return View(uHomeVm);
        }

        public async Task<IActionResult> Delete(int cartid)
        {
            await _cartService.DeleteById(cartid);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddtoCart(int usid, int proid)
        {
            await _cartService.AddToCart(usid, proid);
            return RedirectToAction("Index");
        }


        public IActionResult Details()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}