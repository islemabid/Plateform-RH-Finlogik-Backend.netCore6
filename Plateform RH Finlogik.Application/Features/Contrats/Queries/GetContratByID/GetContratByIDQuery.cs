using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratByID
{
    public class GetContratByIDQuery : IRequest<ContratByIDdetails>
    {
        public int Id { get; set; }
    }
   
}
