using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class TimeOffBalances
    {
        public  int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime  EndDate { get; set; }
        public bool IsActive { get; set; }
        public string   Type { get; set; }

        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }






    }
}
