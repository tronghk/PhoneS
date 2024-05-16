using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Bill
    {
        [Key]
     

        public int BillID { get; set; }

        public DateTime DateCreated { get; set; }

        public float MoneySum { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Voucher")]
        public int VoucherID { get; set; }
        public Voucher Voucher { get; set; }



        public ICollection<ProductBill> ProductBill { get; set; }
    }
}
