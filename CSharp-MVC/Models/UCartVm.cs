namespace CSharp_MVC.Models
{
    public class UCartVm
    {
        public IEnumerable<ProductVm> Products { get; set; }
        public IEnumerable<CartVm> Cart { get; set; }
    }
}
