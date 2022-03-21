using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Departements.Commands.CreateDepartement
{
    public class CreateDepartementCommand : IRequest<int>
    {
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
    }
}
