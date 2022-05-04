using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class TimeOffBalances
    {
        [Key]
        public  int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateQuantity { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateQuantity { get; set; }
        public bool IsActive { get; set; }
        public string  State { get; set; }
         public string? Comment { get; set; }

        [ForeignKey("LeaveType")]
        public int IdLeaveType { get; set; }

        public virtual LeaveType LeaveType { get; set; }

        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }






    }
}
