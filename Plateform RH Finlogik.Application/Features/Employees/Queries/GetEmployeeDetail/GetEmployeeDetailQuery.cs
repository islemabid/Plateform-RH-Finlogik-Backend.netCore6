using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailVm>
    {
        public int Id { get; set; }
    }
    
}
