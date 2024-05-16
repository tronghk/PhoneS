using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee
    {
        [Key]
     
        public int EmployeeID { get; set; }
        public string FullName { get; set; }

        public string Nationality { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public float Salary { get; set; }

        public float CoefSalary { get; set; }

        public string Account { get; set; }
        public ICollection<Bill> Bill { get; set; }
    }
}
