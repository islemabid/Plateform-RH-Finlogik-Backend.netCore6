using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatsList
{
    public class GetCandidatsListQuery : IRequest<List<CandidatsListVm>>
    {
    }
}
