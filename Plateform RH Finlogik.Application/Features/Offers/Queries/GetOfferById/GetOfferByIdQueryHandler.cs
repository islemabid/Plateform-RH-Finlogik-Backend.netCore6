using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Offers.Queries.GetOfferById
{
    public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, OfferVm>
    {
        private readonly IAsyncRepository<Offer> _offerRepository;
        private readonly IMapper _mapper;

        public GetOfferByIdQueryHandler(IMapper mapper, IAsyncRepository<Offer> offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;

        }

        public async Task<OfferVm> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var @offer = await _offerRepository.GetByIDAsync(request.Id);
            var offerDetail = _mapper.Map<OfferVm>(@offer);
            return offerDetail;

        }
    }
}
