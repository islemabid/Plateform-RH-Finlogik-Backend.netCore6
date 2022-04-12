using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatByID
{
    public class GetCandidatByIDQueryHandler : IRequestHandler<GetCandidatByIDQuery, CandidatDetails>
    {
        private readonly IAsyncRepository<Candidat> _candidatRepository;
        private readonly IMapper _mapper;

        public GetCandidatByIDQueryHandler(IMapper mapper, IAsyncRepository<Candidat> candidatRepository)
        {
            _mapper = mapper;
            _candidatRepository = candidatRepository;

        }

        public async Task<CandidatDetails> Handle(GetCandidatByIDQuery request, CancellationToken cancellationToken)
        {
            var @candidat = await _candidatRepository.GetByIDAsync(request.Id);
            var candidatDetail = _mapper.Map<CandidatDetails>(@candidat);
            return candidatDetail;

        }
    }

}

  

