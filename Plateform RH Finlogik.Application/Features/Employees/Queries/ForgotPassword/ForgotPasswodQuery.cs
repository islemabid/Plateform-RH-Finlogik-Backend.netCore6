using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.ForgotPassword
{

    public class ForgotPasswodQuery : IRequest<ForgotPasswordDto>
    {
        public string WorkEmail { get; set; }

    }
}
