
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Commands.createEmployeePost
{
    public class CreateEmployeePostCommand : IRequest<int>
    {
        public int IdPost { get; set; }

        public int IdEmployee { get; set; }

        public DateTime StartDate { get; set; }=DateTime.Now;
        public bool isActive { get; set; } = true;
    }
}
