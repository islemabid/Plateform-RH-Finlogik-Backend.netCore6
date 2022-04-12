using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatByID
{
    public class GetCandidatByIDQuery : IRequest<CandidatDetails>
    {
        public int Id { get; set; }
    }

}

