using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
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
        public string Cin { get; set; }
        public string WorkEmail { get; set; }
        public int WorkPhone { get; set; }
        public string Diplome { get; set; }
        public string CNSSNumber { get; set; }
        public bool isActive { get; set; } = true;
        public string? ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IdRole { get; set; }
        public int IdPost { get; set; }
        public int IdContrat { get; set; }
        public int IdDepartement { get; set; }

    }
}
