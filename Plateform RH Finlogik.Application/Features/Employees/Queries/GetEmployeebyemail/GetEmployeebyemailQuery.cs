

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeebyemail
{
    public  class GetEmployeebyemailQuery : IRequest<EmployeeByEmail>
    {
        public string WorkEmail { get; set; }
    }
}
