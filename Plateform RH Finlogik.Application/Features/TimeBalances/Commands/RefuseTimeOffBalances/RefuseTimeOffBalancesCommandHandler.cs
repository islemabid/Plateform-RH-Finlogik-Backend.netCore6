﻿using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.RefuseTimeOffBalances
{
    public class RefuseTimeOffBalancesCommandHandler : IRequestHandler<RefuseTimeOffBalancesCommand>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;

        public RefuseTimeOffBalancesCommandHandler(IMapper mapper,  ItimeoffBalancesRepository timeoffbalanceRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
          

        }

        public async Task<Unit> Handle(RefuseTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {

            var timeoffbalnceToUpdate = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalnceToUpdate == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances), request.Id);
            }

            request.State = "rejected";
            _mapper.Map(request, timeoffbalnceToUpdate, typeof(RefuseTimeOffBalancesCommand), typeof(TimeOffBalances));

            await _timeoffbalanceRepository.UpdateAsync(timeoffbalnceToUpdate);

            return Unit.Value;
        }

    }
}