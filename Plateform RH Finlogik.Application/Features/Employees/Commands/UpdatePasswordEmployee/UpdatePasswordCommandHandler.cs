
using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Helpers;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdatePasswordEmployee
{

    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public UpdatePasswordCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;

        }

        public async Task<Unit> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            string passwordCrypted = Helper.Encrypt(request.Password);
            var employeUpdated = await _employeeRepository.UpdateUserPassword(request.WorkEmail, passwordCrypted);

            _mapper.Map(request, employeUpdated, typeof(UpdatePasswordCommand), typeof(Employee));

          

            return Unit.Value;

        }
    }

}
