using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    {
        [Key]
    
        public int CustomerID { get; set; }
        public string? FullName { get; set; }

        public string? Nationality { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Account { get; set; }

        public ICollection<Bill> Bill { get; set; }
    }
}
