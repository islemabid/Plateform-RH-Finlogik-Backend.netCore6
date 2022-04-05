﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer
{
    public class CreateApplicationOfferCommand : IRequest<int>
    {
        public int IdOffer { get; set; }


        public int IdCandidat { get; set; }

        public DateTime AssignmentDate { get; set; }
        public string CvUrl { get; set; }

        public string CoverLetter { get; set; }
    }
}