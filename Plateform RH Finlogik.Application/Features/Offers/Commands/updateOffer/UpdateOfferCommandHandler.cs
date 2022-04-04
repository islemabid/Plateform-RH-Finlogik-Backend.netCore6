using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Commands.updateOffer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand>
    {
        private readonly IAsyncRepository<Offer> _offerRepository;
        private readonly IMapper _mapper;

        public UpdateOfferCommandHandler(IMapper mapper, IAsyncRepository<Offer> offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<Unit> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {

            var offerToUpdate = await _offerRepository.GetByIDAsync(request.Id);

            if (offerToUpdate == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }



            _mapper.Map(request, offerToUpdate, typeof(UpdateOfferCommand), typeof(Offer));

            await _offerRepository.UpdateAsync(offerToUpdate);

            return Unit.Value;
        }

    }

}