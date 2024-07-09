namespace CSharp_MVC.Models
{
    public class UHomeVm
    {
        public IEnumerable<ProductVm> Products { get; set; }
        public IEnumerable<ProductCategoryVm> Categories { get; set; }
        public IEnumerable<CartVm> Cart { get; set; }

        public IEnumerable<ProductVm> ListPView { get; set; }
    }
}
