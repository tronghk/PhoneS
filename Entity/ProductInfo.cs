using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductInfo
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

        [Key]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
