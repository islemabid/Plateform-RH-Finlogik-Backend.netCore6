using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdatePasswordEmployee
{
    public class UpdatePasswordCommand : IRequest
    {
        public string WorkEmail { get; set; }

        public string Password { get; set; }

    }
}
