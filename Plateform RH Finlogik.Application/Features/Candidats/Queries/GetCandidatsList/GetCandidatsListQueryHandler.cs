using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Candidats.Queries.GetCandidatsList
{
    public class GetCandidatsListQueryHandler : IRequestHandler<GetCandidatsListQuery, List<CandidatsListVm>>
    {
        private readonly IAsyncRepository<Candidat> _candidatRepository;
        private readonly IMapper _mapper;

        public GetCandidatsListQueryHandler(IMapper mapper, IAsyncRepository<Candidat> candidatRepository)
        {
            _mapper = mapper;
            _candidatRepository = candidatRepository;
        }

        public async Task<List<CandidatsListVm>> Handle(GetCandidatsListQuery request, CancellationToken cancellationToken)
        {
            var allcandidats = (await _candidatRepository.GetAllAsync()).OrderByDescending(x=>x.Id);
            return _mapper.Map<List<CandidatsListVm>>(allcandidats);
        }

    }

}

    

