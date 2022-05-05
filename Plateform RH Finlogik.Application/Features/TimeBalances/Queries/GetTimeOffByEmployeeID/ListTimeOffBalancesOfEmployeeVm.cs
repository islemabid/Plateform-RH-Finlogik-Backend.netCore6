using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffByEmployeeID
{
    public  class ListTimeOffBalancesOfEmployeeVm
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string State { get; set; }
        public int IdEmployee { get; set; }
        public virtual Employee Employee { get; set; }
        public string? Comment { get; set; }
        public int IdLeaveType { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        public string StartDateQuantity { get; set; }
        public string EndDateQuantity { get; set; }



    }
}
