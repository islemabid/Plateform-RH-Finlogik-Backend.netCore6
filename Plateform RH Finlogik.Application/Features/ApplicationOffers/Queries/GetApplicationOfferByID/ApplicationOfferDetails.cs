using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOfferByID
{
    public class ApplicationOfferDetails
    {
       

        public int IdOffer { get; set; }

        public Offer Offer { get; set; }

        public int IdCandidat { get; set; }

        public Candidat Candidat { get; set; }
    }
}
