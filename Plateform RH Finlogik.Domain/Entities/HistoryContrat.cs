using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class HistoryContrat
    {
        [Key]
        public int Id { get; set; }
        public int IdContrat { get; set; }

        public virtual Contrat Contrat { get; set; }

        public int IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public bool isActive { get; set; }
    }
}
