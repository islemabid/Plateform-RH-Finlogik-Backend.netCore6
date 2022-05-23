

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Commands.UpdateEmployeePay
{
    public class UpdateEmployeePayCommand : IRequest
    {
        public int Id { get; set; }
        public long FixedSalary { get; set; }
        public string Year { get; set; }
        public string Mounth { get; set; }
        public int? MealTicket { get; set; }
        public int? TicketPassGift { get; set; }
        public float? Prime { get; set; }
        public string status { get; set; } 
        public int IdEmployee { get; set; }
    }
}
