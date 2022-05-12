

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class EmployeePay
    {
        [Key]
        public int Id { get; set; }
        public string Year { get; set; }
        public string Mounth { get; set; }
        public long FixedSalary { get; set; }
        public int? MealTicket { get; set; }
        public int? TicketPassGift { get; set; }
        public int? Prime { get; set; }

        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }



    }
}
