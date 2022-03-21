﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Departement
    {

        [Key]

        public int Id { get; set; }
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

       
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
