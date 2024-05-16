using CSharp_MVC.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.implementation;
using System.Drawing.Printing;

namespace CSharp_MVC.Controllers
{
    public class UProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _procateCategoryService;
        private readonly IProductSaleService _productSaleService;
        private readonly ICartService _cartService;

        public UProductsController(IProductService productService, IProductCategoryService procateCategoryService, IProductSaleService productSaleService, ICartService cartService)
        {
            _productService = productService;
            _procateCategoryService = procateCategoryService;
            _productSaleService = productSaleService;
            _cartService = cartService;
        }
        [Route("products")]
        public IActionResult Index(int pageNumber = 1, int pageSize = 12)
        {

            var products = _productService.GetProducts(pageNumber, pageSize);

            var productcategory = _procateCategoryService.GetAllProduct();

            var productsale = _productSaleService.GetAllProductSale();

            var totalItems = _productService.GetTotalCount();

            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var hasPreviousPage = (pageNumber > 1);

            var hasNextPage = (pageNumber < totalPages);

            var cart = _cartService.GetAll().Select(entity => new CartVm
            {
                CartID = entity.CartID,
                Quantity = entity.Quantity,
                UserID = entity.UserID,
                ProductID = entity.ProductID
            }).ToList();

            var productsforcart = _productService.GetAll().Select(entity => new ProductVm
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

            var paginationViewModel = new StoreVm
            {
                Products = products.Result,
                Pagination = new Pagination
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    HasPreviousPage = hasPreviousPage,
                    HasNextPage = hasNextPage
                },
                ProductCategory = productcategory.Result,
                ProductSale = productsale.Result,
                Cart = cart,
                ProductsforCart = productsforcart
            };
            return View(paginationViewModel);


        }
        [Route("products/category/{categoryId}")]
        public IActionResult Index(int categoryId, int pageNumber = 1, int pageSize = 12)
        {
            var products = _productService.GetProductsByCategory(categoryId, pageNumber, pageSize);

            var productcategory = _procateCategoryService.GetAllProduct();

            var productsale = _productSaleService.GetAllProductSale();

            int totalItems = _productService.GetTotalCount();

            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var hasPreviousPage = (pageNumber > 1);

            var hasNextPage = (pageNumber < totalPages);

            var paginationViewModel = new StoreVm
            {
                Products = products.Result,
                Pagination = new Pagination
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    HasPreviousPage = hasPreviousPage,
                    HasNextPage = hasNextPage
                },
                ProductCategory = productcategory.Result,
                ProductSale = productsale.Result
            };
            return View(paginationViewModel);
        }

        //[HttpGet]
        //public async Task<IActionResult> AddToCart(int id)
        //{
        //    // Get the product with the specified id
        //    var product = await _productService.GetProductById(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    // Create a JSON response with the product information
        //    var response = new
        //    {
        //        name = product.Name,
        //        price = product.Price
        //    };

        //    // Return the JSON response
        //    return Json(response);
        //}


    }
}
