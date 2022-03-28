using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.CreateTimeOffBalances
{
    public class CreateTimeOffBalancesCommandHandler : IRequestHandler<CreateTimeOffBalancesCommand, int>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public CreateTimeOffBalancesCommandHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
        }

        public async Task<int> Handle(CreateTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {
            var @timeoffbalance= _mapper.Map<TimeOffBalances>(request);

            @timeoffbalance = await _timeoffbalanceRepository.AddAsync(@timeoffbalance);



            return @timeoffbalance.Id;

        }

    }
}
