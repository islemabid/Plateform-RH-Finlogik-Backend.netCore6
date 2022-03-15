using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.AffecterEmployeePost
{
    public class AffectEmployeePostCommand :IRequest
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
    } 

}
