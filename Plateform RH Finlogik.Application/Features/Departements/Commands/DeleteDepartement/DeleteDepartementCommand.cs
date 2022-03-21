using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Departements.Commands.DeleteDepartement
{
    public class DeleteDepartementCommand : IRequest
    {
        public int Id { get; set; }


    }
}
