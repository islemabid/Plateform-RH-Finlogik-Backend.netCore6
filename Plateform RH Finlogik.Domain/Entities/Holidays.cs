
using System.ComponentModel.DataAnnotations;


namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Holidays
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
         public DateTime Date { get; set; }
      
        
    }
}
