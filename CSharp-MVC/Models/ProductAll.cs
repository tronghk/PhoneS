namespace CSharp_MVC.Models
{
    public class ProductAll
    {
        public string Screen { get; set; }
        public string OS { get; set; }
        public string FrontCam { get; set; }
        public string BackCam { get; set; }
        public string Chip { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string SIM { get; set; }
        public string Battery { get; set; }

        public int ProductID { get; set; }

        public string? ProductName { get; set; }

        public float Price { get; set; }
        public string? Picture { get; set; }

        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int? Category { get; set; }
    }
}
