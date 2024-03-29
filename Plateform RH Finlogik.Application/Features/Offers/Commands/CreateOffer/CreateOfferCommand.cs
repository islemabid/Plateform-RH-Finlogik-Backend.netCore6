﻿using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.Offers.Commands.CreateOffer
{
    public  class CreateOfferCommand : IRequest<int>
    {

        public string OfferDescription { get; set; }
        public string OfferName { get; set; }
        public int OfferMinExperience { get; set; }
        public string type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
