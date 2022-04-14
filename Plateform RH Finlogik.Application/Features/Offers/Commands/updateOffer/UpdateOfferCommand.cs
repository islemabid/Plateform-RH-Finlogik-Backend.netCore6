using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Offers.Commands.updateOffer
{
    public class UpdateOfferCommand : IRequest
    {

        public int Id { get; set; }
        public string OfferDescription { get; set; }
        public string OfferName { get; set; }
        public int OfferMinExperience { get; set; }
        public string type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
