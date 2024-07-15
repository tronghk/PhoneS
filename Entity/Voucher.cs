using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Voucher
    {
        [Key]
        public int VoucherID { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
       
        public string Code { get; set; }
        public float PriceSale { get; set;}

        public int UseTimess { get; set; }

        public ICollection<Bill> Bill { get; set; }
    }
}
