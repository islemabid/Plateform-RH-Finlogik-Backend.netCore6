﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.DeleteTimeOffBalances
{
     class DeleteTimeOffBalancesCommandHandler : IRequestHandler<DeleteTimeOffBalancesCommand>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public DeleteTimeOffBalancesCommandHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
        }

        public async Task<Unit> Handle(DeleteTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {
            var timeoffbalancesToDelete = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalancesToDelete == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances), request.Id);
            }
            timeoffbalancesToDelete.IsActive = false;

            var timeoffbalancesDelete = await _timeoffbalanceRepository.UpdateAsync(timeoffbalancesToDelete);

            return Unit.Value;
        }

    }


}

