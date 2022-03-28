using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratByID
{
    public class GetContratByIDQueryHandler : IRequestHandler<GetContratByIDQuery, ContratByIDdetails>
    {
        private readonly IAsyncRepository<Contrat> _contratRepository;
        private readonly IMapper _mapper;

        public GetContratByIDQueryHandler(IMapper mapper, IAsyncRepository<Contrat> contratRepository)
        {
            _mapper = mapper;
            _contratRepository = contratRepository;

        }

        public async Task<ContratByIDdetails> Handle(GetContratByIDQuery request, CancellationToken cancellationToken)
        {
            var @contrat = await _contratRepository.GetByIDAsync(request.Id);
            var contratDetail = _mapper.Map<ContratByIDdetails>(@contrat);
            return contratDetail;

        }
    }

}
