using MediatR;
using Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees
{
    public  class GetEmployeesListQuery :IRequest<List<EmployeeListVm>>
    {
    }
}
