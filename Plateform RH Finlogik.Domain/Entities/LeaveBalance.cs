
using System.ComponentModel.DataAnnotations;


namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class LeaveBalance
    {
        [Key]
        public int Id { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }

        public int IdLeaveType { get; set; }

        public virtual LeaveType LeaveType { get; set; }
        public float numberDays { get; set; }
    }
}
