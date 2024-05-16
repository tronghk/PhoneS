﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Role
    {
        [Key]
        
        public int RoleId {  get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public ICollection<User> User { get; set; }

    }
}
