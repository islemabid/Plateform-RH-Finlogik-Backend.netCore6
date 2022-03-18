using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetEmployeesPostsList
{
    public class EmployeePostListVm
    {
        public int IdPost { get; set; }

        public Post Post { get; set; }
        public int IdEmployee { get; set; }

        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }

    }
}
