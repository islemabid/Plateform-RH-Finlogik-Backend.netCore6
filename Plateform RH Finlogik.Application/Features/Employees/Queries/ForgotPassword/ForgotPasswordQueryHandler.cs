

using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.ForgotPassword
{

    public class ForgotPasswordQueryHandler : IRequestHandler<ForgotPasswodQuery, ForgotPasswordDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ForgotPasswordQueryHandler(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;

        }

        public async Task<ForgotPasswordDto> Handle(ForgotPasswodQuery request, CancellationToken cancellationToken)
        {
            var employe = _employeeRepository.GetUserByEmail(request.WorkEmail);
            if (employe != null)
            {
                ForgotPasswordDto @employeeDTo = new ForgotPasswordDto
                {
                    Cin = employe.Cin,
                    Id = employe.Id,
                    FirstName = employe.FirstName,
                    LastName = employe.LastName,
                    WorkEmail = employe.WorkEmail
                };
                return @employeeDTo;
            }

            else
            {

                throw new Exception($"error");
            }
        }
    }

}
