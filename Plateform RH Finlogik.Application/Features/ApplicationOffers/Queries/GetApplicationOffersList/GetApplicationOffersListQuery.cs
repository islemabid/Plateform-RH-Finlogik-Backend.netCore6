using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Queries.GetApplicationOffersList
{
    public class GetApplicationOffersListQuery : IRequest<List<ApplicationOffersListVm>>
    {
    }
}
