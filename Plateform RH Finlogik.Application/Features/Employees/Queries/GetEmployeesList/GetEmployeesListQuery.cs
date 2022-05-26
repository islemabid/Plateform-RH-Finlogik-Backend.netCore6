using MediatR;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;


namespace Plateform_RH_Finlogik.Application.Features.Employees
{
    public  class GetEmployeesListQuery :IRequest<List<EmployeeListVm>>
    {
    }
}
