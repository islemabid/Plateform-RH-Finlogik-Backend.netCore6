

using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Commands.UpdateEmployeePay
{
    public class UpdateEmployeePayCommandHandler : IRequestHandler<UpdateEmployeePayCommand>
    {
        private readonly IEmployeePayRepository _payRepository;
        private readonly IMapper _mapper;
        public UpdateEmployeePayCommandHandler(IMapper mapper, IEmployeePayRepository payRepository)
        {
            _mapper = mapper;
            _payRepository = payRepository;

        }
        public async Task<Unit> Handle(UpdateEmployeePayCommand request, CancellationToken cancellationToken)
        {
            var employeePayToUpdate = await _payRepository.GetByIDAsync(request.Id);

            if (employeePayToUpdate == null)
            {
                throw new NotFoundException(nameof(EmployeePay), request.Id);
            }

            request.status = "Payed";

            _mapper.Map(request, employeePayToUpdate, typeof(UpdateEmployeePayCommand), typeof(EmployeePay));

            await _payRepository.UpdateAsync(employeePayToUpdate);

            return Unit.Value;
        }
    }
}
