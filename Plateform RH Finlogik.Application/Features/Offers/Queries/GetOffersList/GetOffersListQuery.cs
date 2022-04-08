using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Offers.Queries.GetOffersList
{
    public class GetOffersListQuery : IRequest<List<OffersListVm>>
    { 
    }
}
