using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
