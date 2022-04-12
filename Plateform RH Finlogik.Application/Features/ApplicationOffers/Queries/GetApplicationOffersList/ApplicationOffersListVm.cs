using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOffersList
{
    public class ApplicationOffersListVm
    {
        public int Id { get; set; }

        public int IdOffer { get; set; }

        public Offer Offer { get; set; }

        public int IdCandidat { get; set; }

        public  Candidat Candidat { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string CvUrl { get; set; }

        public string CoverLetter { get; set; }
    }
}
