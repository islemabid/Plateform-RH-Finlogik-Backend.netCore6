using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
