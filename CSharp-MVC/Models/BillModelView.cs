namespace CSharp_MVC.Models
{
    public class BillModelView
    {
        public int BillID { get; set; }
        public DateTime DateCreated { get; set; }
        public float MoneySum { get; set; }
        public string employee { get; set; }
        public string customer { get; set; }
        public float VoucherID { get; set; }
    }
}
