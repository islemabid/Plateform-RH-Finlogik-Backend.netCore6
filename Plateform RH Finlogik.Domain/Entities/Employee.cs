
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Employee 
    {
        [Key]

        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonnelEmail { get; set; }
        public int PersonnelPhone { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Contry { get; set; }
        public string Region { get; set; }
        public int postalCode { get; set; }
        public long Cin  { get; set; }
        public string WorkEmail { get; set; }
        public int  WorkPhone { get; set; }
        public string Diplome { get; set; }
        public string CNSSNumber { get; set; }
        public float  HoursPerWeek { get; set; }

        [ForeignKey("Departement")]
        public int IdDepartement { get; set; }

        public virtual Departement Departement { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }

        public virtual Role Role { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeePost> EmployeePosts { get; set; }
        public virtual ICollection<HistoryContrat> HistoryContrats { get; set; }
        public virtual ICollection<TimeOffBalances> TimeOffBalances { get; set; }



       



    }
}
