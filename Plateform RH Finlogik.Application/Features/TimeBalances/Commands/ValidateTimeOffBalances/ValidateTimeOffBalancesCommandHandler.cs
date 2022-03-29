using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.ValidateTimeOffBalances
{
    public class ValidateTimeOffBalancesCommandHandler : IRequestHandler<ValidateTimeOffBalancesCommand>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public ValidateTimeOffBalancesCommandHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
        }

        public async Task<Unit> Handle(ValidateTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {

            var timeoffbalnceToUpdate = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalnceToUpdate == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances ), request.Id);
            }

            if (timeoffbalnceToUpdate.IsActive == false)
            {
                timeoffbalnceToUpdate.IsActive=true;
            }

            _mapper.Map(request, timeoffbalnceToUpdate, typeof(ValidateTimeOffBalancesCommand), typeof(TimeOffBalances));

            await _timeoffbalanceRepository.UpdateAsync(timeoffbalnceToUpdate);

            return Unit.Value;
        }

    }

}
 

