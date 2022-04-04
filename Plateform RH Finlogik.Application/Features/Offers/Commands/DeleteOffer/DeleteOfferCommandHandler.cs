﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Commands.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand>
    {
        private readonly IAsyncRepository<Offer> _offerRepository;
        private readonly IMapper _mapper;

        public DeleteOfferCommandHandler(IMapper mapper, IAsyncRepository<Offer> offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<Unit> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var offerToDelete = await _offerRepository.GetByIDAsync(request.Id);

            if (offerToDelete == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }
            await _offerRepository.DeleteAsync(offerToDelete);

            return Unit.Value;
        }

    }


}
