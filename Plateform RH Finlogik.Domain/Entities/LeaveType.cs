
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<LeaveBalance> LeaveBalance { get; set; }

    }
}
