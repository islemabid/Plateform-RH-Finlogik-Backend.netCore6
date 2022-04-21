using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOfferByID
{
    public  class GetApplicationOfferByIdQueryHandler : IRequestHandler<GetApplicationOfferByIdQuery, ApplicationOfferDetails>
    {
        private readonly IApplicationOfferRepository _applicationOfferRepository;
        private readonly IAsyncRepository<Offer> _offerRepository;
        private readonly IAsyncRepository<Candidat> _candidatRepository;

        public GetApplicationOfferByIdQueryHandler( IApplicationOfferRepository applicationOfferRepository, IAsyncRepository<Offer> offerRepository, IAsyncRepository<Candidat> candidatRepository)
        {
            
            _applicationOfferRepository = applicationOfferRepository;
            _offerRepository=offerRepository;
            _candidatRepository = candidatRepository;

        }

        public async Task<ApplicationOfferDetails> Handle(GetApplicationOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var @application =  await _applicationOfferRepository.GetByIDAsync(request.Id);
            return new ApplicationOfferDetails()
            {
                IdOffer = application.IdOffer,
                Offer=await _offerRepository.GetByIDAsync(@application.IdOffer),
                IdCandidat = application.IdCandidat,
                Candidat=await _candidatRepository.GetByIDAsync(application.IdCandidat)
            };

        }
    }
    
}
