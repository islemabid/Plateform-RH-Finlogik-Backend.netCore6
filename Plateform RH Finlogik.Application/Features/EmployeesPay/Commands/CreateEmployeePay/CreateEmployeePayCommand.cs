using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Commands.CreateEmployeePay
{
    public  class CreateEmployeePayCommand : IRequest<int>
    {
        public long FixedSalary { get; set; }
        public string Year { get; set; }
        public string Mounth { get; set; }
        public int? MealTicket { get; set; }
        public int? TicketPassGift { get; set; }
        public float? Prime { get; set; }
        public int IdEmployee { get; set; }
    }
}
