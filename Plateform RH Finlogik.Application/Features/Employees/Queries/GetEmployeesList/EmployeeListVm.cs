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
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
