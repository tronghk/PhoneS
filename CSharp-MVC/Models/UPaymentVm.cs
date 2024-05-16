namespace CSharp_MVC.Models
{
    public class UPaymentVm
    {
        public IEnumerable<ProductVm> Products { get; set; }
        public IEnumerable<CartVm> Cart { get; set; }
        public IEnumerable<UserPaymentVm> User { get; set; }
    }
}
