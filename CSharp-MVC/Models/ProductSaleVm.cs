namespace CSharp_MVC.Models
{
    public class ProductSaleVm
    {
        public int ProdSaleID { get; set; }
        public DateTime DateStarted { get; set; }

        public DateTime DateEnded { get; set; }

        public float PercentSale { get; set; }
        public float PriceSale { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
