using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.UpdateTimeOffBalances
{
    public class UpdateTimeOffBalancesCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = false;
        public string Type { get; set; }
        public int IdEmployee { get; set; }
        public string State { get; set; } = "waiting";
    }

}
