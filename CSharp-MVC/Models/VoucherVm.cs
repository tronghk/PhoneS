namespace CSharp_MVC.Models
{
    public class VoucherVm
    {
        public int VoucherID { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
        public string Code { get; set; }
        public float PriceSale { get; set; }

        public int UseTimess { get; set; }

    }
}
