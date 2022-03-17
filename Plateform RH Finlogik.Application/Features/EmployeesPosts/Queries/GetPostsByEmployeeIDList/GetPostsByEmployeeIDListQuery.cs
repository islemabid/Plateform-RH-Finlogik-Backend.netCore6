using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPosts.Queries.GetPostsByEmployeeIDList
{
    public class GetPostsByEmployeeIDListQuery : IRequest<List<PostListByIDEmployeeVm>>
    {
        public int IdEmployee { get; set; }
    }
}
