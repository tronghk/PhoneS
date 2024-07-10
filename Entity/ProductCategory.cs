using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductCategory
    {
        [Key]
      
        public int ProdCateID { get; set; }

        public string ProdCateName { get; set; }
        public string linkImage { get; set; }

        public ICollection<Product> Product { get;}
    }
}
