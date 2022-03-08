using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList
{
    public class EmployeeListVm
    {
        public int Id { get; set; }
        public long Cin { get; set; }
        public string WorkEmail { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
