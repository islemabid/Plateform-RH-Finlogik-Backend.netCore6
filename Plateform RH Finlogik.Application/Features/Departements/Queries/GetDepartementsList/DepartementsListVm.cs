using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Departements.Queries.GetDepartementsList
{
    public class DepartementsListVm
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
    }
}
