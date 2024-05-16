using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductBill
    {
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Bill")]
        public int BillID { get; set; }
        public int Quantity { get; set; }
    }
}
