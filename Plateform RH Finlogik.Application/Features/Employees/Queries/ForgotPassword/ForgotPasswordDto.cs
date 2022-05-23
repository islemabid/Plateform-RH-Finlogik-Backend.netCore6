
namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.ForgotPassword
{
    public class ForgotPasswordDto
    {
        public int Id { get; set; }
        public long Cin { get; set; }
        public string WorkEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
