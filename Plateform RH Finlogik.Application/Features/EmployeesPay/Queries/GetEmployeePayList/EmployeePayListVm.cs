
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetEmployeePayList
{
    public class EmployeePayListVm
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Mounth { get; set; }
        public long FixedSalary { get; set; }
        public int? MealTicket { get; set; }
        public int? TicketPassGift { get; set; }
        public float? Prime { get; set; }
        public int IdEmployee { get; set; }
        public string employeeFullName { get; set; }
    }
}
