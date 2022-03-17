using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetPostsByEmployeeIDList
{
    public class PostListByIDEmployeeVm
    {
        public int IdPost { get; set; }

        public int IdEmployee { get; set; }

        public DateTime StartDate { get; set; }
    }
}
