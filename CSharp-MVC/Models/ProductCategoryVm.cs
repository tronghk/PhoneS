namespace CSharp_MVC.Models
{
    public class ProductCategoryVm
    {
        public int ProdCateID { get; set; }

        public string ProdCateName { get; set; }
        public IFormFile linkImage { get; set; }

        public string nameImage { get; set; }
    }
}
