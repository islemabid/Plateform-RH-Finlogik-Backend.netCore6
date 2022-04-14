
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Offer
    {
        [Key]

        public int Id { get; set; }
        public string OfferDescription { get; set; }
        public string OfferName { get; set; }
        public int OfferMinExperience { get; set; }
        public string type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<ApplicationOffer> ApplicationOffers { get; set; }
    }
}
