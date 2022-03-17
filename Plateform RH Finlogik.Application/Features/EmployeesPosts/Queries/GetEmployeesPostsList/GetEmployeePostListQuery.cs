using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetEmployeesPostsList
{
    public class GetEmployeePostListQuery : IRequest<List<EmployeePostListVm>>
    {
    }
}
