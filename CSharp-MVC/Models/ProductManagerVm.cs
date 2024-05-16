namespace CSharp_MVC.Models
{
    public class ProductManagerVm
    {
        public int ProductID { get; set; }

        public string? ProductName { get; set; }

        public float Price { get; set; }
        public string? Picture { get; set; }

        public int Quantity { get; set; }
        public string? Description { get; set; }

        public string? Category { get; set; }
    }
}
