using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.ValidateTimeOffBalances
{
    public class ValidateTimeOffBalancesCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = false;
        public string? Comment { get; set; }
        public int IdLeaveType { get; set; }
        public int IdEmployee { get; set; }
        public string State { get; set; } = "waiting";
        public string StartDateQuantity { get; set; }
        public string EndDateQuantity { get; set; }

    }

}
