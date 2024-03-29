﻿using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Offers.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
    {
        private readonly IAsyncRepository<Offer> _offerRepository;
        private readonly IMapper _mapper;
        public CreateOfferCommandHandler(IMapper mapper, IAsyncRepository<Offer> offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;

        }

        public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            if (request != null && request.type!="" && request.OfferMinExperience != null && request.OfferName != "" && request.ExpirationDate!=null)
            {
                var @offer = _mapper.Map<Offer>(request);

                @offer = await _offerRepository.AddAsync(@offer);



                return @offer.Id;
            }
            else
            {
                throw new Exception($"failed");
            }

        }

    }
}
