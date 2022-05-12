using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetHistoryPayOfEmployee
{
    public class GetHistoryPayOfEmployeeQuery : IRequest<List<HistoryPayVm>>
    {
        public int IdEmployee { get; set; }
    
    }
}
