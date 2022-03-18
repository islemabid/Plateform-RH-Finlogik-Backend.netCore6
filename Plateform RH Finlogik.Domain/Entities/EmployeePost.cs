using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class EmployeePost
    {

        [Key]
        public int Id { get; set; }
        public int IdPost { get; set; }
   
        public virtual Post Post { get; set; }

        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }

        public  DateTime StartDate { get; set; }
        public bool isActive { get; set; }
    }
}
