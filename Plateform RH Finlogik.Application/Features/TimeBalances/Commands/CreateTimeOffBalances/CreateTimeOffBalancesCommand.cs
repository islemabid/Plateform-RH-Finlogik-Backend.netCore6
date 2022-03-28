using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.CreateTimeOffBalances
{
    public class CreateTimeOffBalancesCommand : IRequest<int>
    {
     
        public DateTime StartDate { get; set; }=DateTime.Now;
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = false;
        public string Type { get; set; }
        public int IdEmployee { get; set; }
    }
}
