using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ?Address { get; set; }
        public string Password { get; set; }
        public string ?PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public string ?Diplome { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }= DateTime.Now;
       
       // public Contract ContractType { get; set; }
       // public int? IdManager { get; set; }


    }
}
