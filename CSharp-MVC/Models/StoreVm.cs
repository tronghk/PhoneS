using Entity;

namespace CSharp_MVC.Models
{
    public class StoreVm
    {
        public IEnumerable<Product> Products { get; set; }
        public Pagination Pagination { get; set; }
        public IEnumerable<ProductCategory> ProductCategory { get; set; }
        public IEnumerable<ProductSale> ProductSale { get; set; }
        public IEnumerable<CartVm> Cart { get; set; }
        public IEnumerable<ProductVm> ProductsforCart { get; set; }
    }
}
