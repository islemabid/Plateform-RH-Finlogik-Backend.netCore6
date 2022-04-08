using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Offers.Commands.DeleteOffer

{
    public class DeleteOfferCommand : IRequest
    {
        public int Id { get; set; }


    }
    
}
