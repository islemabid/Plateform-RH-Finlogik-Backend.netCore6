using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class ApplicationOffer
    {
        [Key]

        public int Id { get; set; }

        public int IdOffer { get; set; }

        public virtual Offer Offer { get; set; }

        public int IdCandidat { get; set; }

        public virtual Candidat Candidat{ get; set; }
        public DateTime AssignmentDate { get; set; }
        public string CvUrl { get; set; }

        public string CoverLetter { get; set; }

    }
}
