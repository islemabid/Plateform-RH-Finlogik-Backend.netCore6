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
        public string Type { get; set; }
        public string State { get; set; }
        public int IdEmployee { get; set; }

   

    }
}
