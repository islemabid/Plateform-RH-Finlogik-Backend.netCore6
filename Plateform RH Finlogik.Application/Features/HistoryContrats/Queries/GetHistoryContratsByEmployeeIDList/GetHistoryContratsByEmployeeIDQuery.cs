using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.HistoryContrats.Queries.GetHistoryContratsByEmployeeIDList
{
    public class GetHistoryContratsByEmployeeIDQuery : IRequest<List<HistoryContratsListByEmployeeIDVm>>
    {
        public int IdEmployee { get; set; }
    }

}
