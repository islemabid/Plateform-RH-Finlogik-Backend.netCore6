using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeListwithTimeoffbalances
{
    public class GetEmployeeListwithTimeoffbalancesQuery : IRequest<List<EmployeeTimeoffbalancesListVm>>
    {
    }
}
