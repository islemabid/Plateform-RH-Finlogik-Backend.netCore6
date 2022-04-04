using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Commands.CreateOffer
{
    public  class CreateOfferCommand : IRequest<int>
    {
 
        public string OfferDescription { get; set; }

        public string OfferName { get; set; }

        public int OfferMinExperience { get; set; }

        public string type { get; set; }
    }
}
