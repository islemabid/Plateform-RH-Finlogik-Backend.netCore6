using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffByEmployeeID
{
    public class GetTimeOffByEmployeeIDQuery : IRequest<List<ListTimeOffBalancesOfEmployeeVm>>
    {
        public int IdEmployee { get; set; }
    }
}
