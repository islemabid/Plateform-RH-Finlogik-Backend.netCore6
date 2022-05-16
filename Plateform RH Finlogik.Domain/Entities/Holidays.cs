
using System.ComponentModel.DataAnnotations;


namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Holidays
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
         public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
