namespace CSharp_MVC.Models
{
    public class BillModel
    {
        public int BillID { get; set; }
        public DateTime DateCreated { get; set; }
        public float MoneySum { get; set; }
        public int EmployeeID { get; set; }
        public float Voucher {  get; set; }

        public List <ProductModel> Products { get; set; }
    }
}
