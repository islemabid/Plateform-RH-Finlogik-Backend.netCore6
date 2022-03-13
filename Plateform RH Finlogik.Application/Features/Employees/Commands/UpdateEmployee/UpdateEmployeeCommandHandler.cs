using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateEmployee
  
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employeeToUpdate = await _employeeRepository.GetByIDAsync(request.Id);

            if (employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

           

            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));

            await _employeeRepository.UpdateAsync(employeeToUpdate);

            return Unit.Value;
        }

    }
}
