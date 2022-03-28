using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeListwithTimeoffbalances
{
     public  class EmployeeTimeoffbalancesListVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Cin { get; set; }
        public virtual ICollection<EmployeeTimeoffbalancesDto> Timeoffbalances { get; set; }
    }
}
