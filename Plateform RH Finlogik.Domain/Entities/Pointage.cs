using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Pointage
    {   [Key]
        public int id { get; set; }

        public DateTime dateAction { get; set; }

        public string action { get; set; }

        public bool IsCalculated { get; set; }

        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }



    }
}
