using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOffersList
{
    public class GetApplicationOffersListQueryHandler : IRequestHandler<GetApplicationOffersListQuery, List<ApplicationOffersListVm>>
    {
        private readonly IApplicationOfferRepository _applicationOfferRepository;
        private readonly IMapper _mapper;

        public GetApplicationOffersListQueryHandler(IMapper mapper, IApplicationOfferRepository applicationOfferRepository)
        {
            _mapper = mapper;
            _applicationOfferRepository = applicationOfferRepository;
        }

        public async Task<List<ApplicationOffersListVm>> Handle(GetApplicationOffersListQuery request, CancellationToken cancellationToken)
        {
            var allApplicationOffers = _applicationOfferRepository.GetAllApplicationOffers();
            return _mapper.Map<List<ApplicationOffersListVm>>(allApplicationOffers);
        }

    }

}






