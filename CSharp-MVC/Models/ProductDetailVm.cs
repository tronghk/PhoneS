namespace CSharp_MVC.Models
{
    public class ProductDetailVm
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public float Price { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int ProdCateID { get; set; }

        public String ProdCateName { get; set; }

        public IEnumerable<ProductImageVm> Imgs { get; set; }
        public string Screen { get; set; }
        public string OS { get; set; }
        public string FrontCam { get; set; }
        public string BackCam { get; set; }
        public string Chip { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string SIM { get; set; }
        public string Battery { get; set; }
        public IEnumerable<CartVm> Cart { get; set; }
        public IEnumerable<ProductVm> Products { get; set; }
    }
}
