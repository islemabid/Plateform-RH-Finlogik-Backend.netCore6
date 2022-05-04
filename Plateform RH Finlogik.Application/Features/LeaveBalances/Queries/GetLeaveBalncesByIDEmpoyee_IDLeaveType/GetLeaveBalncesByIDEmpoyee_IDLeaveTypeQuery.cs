using MediatR;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.LeaveBalances.Queries.GetLeaveBalncesByIDEmpoyee_IDLeaveType
{
    public  class GetLeaveBalncesByIDEmpoyee_IDLeaveTypeQuery : IRequest<LeaveBalancesVm>
    {
        public int IdEmployee { get; set; }
        public int IdLeaveType { get; set; }

    }
}
