using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.DeleteEmployee
{
    public  class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
       

        public DeleteEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
         
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetByIDAsync(request.Id);


                if (employeeToDelete == null)
                {
                    throw new NotFoundException(nameof(Employee), request.Id);
                }

                employeeToDelete.isActive = false;
                await _employeeRepository.UpdateAsync(employeeToDelete);

                return Unit.Value;
            }
            catch (Exception ex) { return Unit.Value; }
        }

    }
}
