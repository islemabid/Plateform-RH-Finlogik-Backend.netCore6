

using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.LeaveBalances.Queries.GetLeaveBalncesByIDEmpoyee_IDLeaveType
{
    public class LeaveBalancesVm
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }

        public int IdLeaveType { get; set; }

        public virtual LeaveType LeaveType { get; set; }
        public float numberDays { get; set; }
    }
}
