using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer
{
    public class CreateApplicationOfferCommandHandler    : IRequestHandler<CreateApplicationOfferCommand, int>
    {
        private readonly IApplicationOfferRepository _applicationOffer;
        private readonly IMapper _mapper;
        public CreateApplicationOfferCommandHandler(IMapper mapper, IApplicationOfferRepository applicationOfferRepository)
        {
            _mapper = mapper;
            _applicationOffer = applicationOfferRepository;

        }

        public async Task<int> Handle(CreateApplicationOfferCommand request, CancellationToken cancellationToken)
        {
            var @applicationOffer = _mapper.Map<ApplicationOffer>(request);

            @applicationOffer = await _applicationOffer.AddAsync(applicationOffer);



            return @applicationOffer.Id;

        }
    }
}

