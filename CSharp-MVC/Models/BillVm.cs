namespace CSharp_MVC.Models
{
    public class BillVm
    {
        public int BillID { get; set; }
        public DateTime DateCreated { get; set; }
        public float MoneySum { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public int VoucherID { get; set; }
    }
}
