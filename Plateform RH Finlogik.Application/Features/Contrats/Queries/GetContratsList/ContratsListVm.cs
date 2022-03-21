using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratsList
{
    public class ContratsListVm
    {

        public int Id { get; set; }
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
    }
}
