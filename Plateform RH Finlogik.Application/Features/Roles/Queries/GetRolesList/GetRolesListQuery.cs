using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRolesListQuery : IRequest<List<RolesListVm>>
    {
    }
}
