using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductSale
    {
        [Key]
       
        public int ProdSaleID { get; set; }
        public DateTime DateStarted { get; set; }

        public DateTime DateEnded { get; set; }

        public float PercentSale { get; set; }
        public float PriceSale { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set;}
        public Product Product { get; set; }
    }
}
