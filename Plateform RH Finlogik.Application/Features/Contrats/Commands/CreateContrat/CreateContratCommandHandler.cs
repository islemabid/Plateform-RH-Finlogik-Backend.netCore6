using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Contrats.Commands.CreateContrat
{
    public class CreateContratCommandHandler : IRequestHandler<CreateContratCommand, int>
    {
        private readonly IContratRepository _contratRepository;
        private readonly IMapper _mapper;
        public CreateContratCommandHandler(IMapper mapper, IContratRepository contratRepository)
        {
            _mapper = mapper;
            _contratRepository = contratRepository;

        }

        public async Task<int> Handle(CreateContratCommand request, CancellationToken cancellationToken)
        {
            var @contrat = _mapper.Map<Contrat>(request);

            @contrat = await _contratRepository.AddAsync(@contrat);



            return @contrat.Id;

        }

    }
}
