using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public float  Price { get; set; }
        public string  Picture { get; set; }

        public int  Quantity { get; set; }
        public string Description { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProdCateID { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public ICollection<ProductSale> ProductSale { get; set; }

        public ICollection<ProductBill> ProductBill { get; set; }

        public ICollection<ProductInfo> ProductInfo { get; set; }
    }

}
