using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail
{
    public class EmployeeDetailVm
    {
        public int Id { get; set; }
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
        public string? ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdRole { get; set; }
        public  Post Post { get; set; }
        public  Contrat Contrat { get; set; }
        public int IdDepartement { get; set; }
    }
}
