using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Queries.GetOffersList
{
    public class GetOffersListQueryHandler : IRequestHandler<GetOffersListQuery, List<OffersListVm>>
    {

        private readonly IAsyncRepository<Offer> _offerRepository;
        private readonly IMapper _mapper;

        public GetOffersListQueryHandler(IMapper mapper, IAsyncRepository<Offer> offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<List<OffersListVm>> Handle(GetOffersListQuery request, CancellationToken cancellationToken)
        {
            var allOffers = await _offerRepository.GetAllAsync();
            return _mapper.Map<List<OffersListVm>>(allOffers);
        }
    }
}

    

