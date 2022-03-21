using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.HistoryContrats.Queries.GetHistoryContratsByEmployeeIDList
{
    public class HistoryContratsListByEmployeeIDVm
    {
        public int IdContrat { get; set; }

        public virtual Contrat Contrat { get; set; }

        public int IdEmployee { get; set; }


        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
