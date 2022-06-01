

using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeebyemail
{
    public class GetEmployeebyemailQueryHandler : IRequestHandler<GetEmployeebyemailQuery, EmployeeByEmail>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeebyemailQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;

        }
        public async Task<EmployeeByEmail> Handle(GetEmployeebyemailQuery request, CancellationToken cancellationToken)
        {
            var employee =  _employeeRepository.GetUserByEmail(request.WorkEmail);
            if (employee != null)
            {
                return _mapper.Map<EmployeeByEmail>(employee);
            }
            else
            {
                throw new Exception($"user found");
            }
        }
    }
}
