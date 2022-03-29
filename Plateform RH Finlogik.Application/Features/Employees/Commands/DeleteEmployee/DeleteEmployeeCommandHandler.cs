using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
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
        private readonly ITerminatedEmployeeRepository _terminatedemployeeRepository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository, ITerminatedEmployeeRepository terminatedemployeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _terminatedemployeeRepository = terminatedemployeeRepository;
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

                var terminatedemployee = new TerminatedEmployee()
                {
                    FirstName = employeeToDelete.FirstName,
                    LastName = employeeToDelete.LastName,
                    Adress = employeeToDelete.Adress,
                    Cin = employeeToDelete.Cin,
                    PersonnelEmail = employeeToDelete.PersonnelEmail,
                    WorkEmail = employeeToDelete.WorkEmail,
                    WorkPhone = employeeToDelete.WorkPhone,
                    ImageUrl = employeeToDelete.ImageUrl,
                    BirthDate = employeeToDelete.BirthDate,
                    City = employeeToDelete.City,
                    Contry = employeeToDelete.Contry,
                    CNSSNumber = employeeToDelete.CNSSNumber,
                    postalCode = employeeToDelete.postalCode,
                    Region = employeeToDelete.Region,
                    Diplome = employeeToDelete.Diplome,
                    Password = employeeToDelete.Password,
                    PersonnelPhone = employeeToDelete.PersonnelPhone,
                    HoursPerWeek = employeeToDelete.HoursPerWeek,
                    Gender = employeeToDelete.Gender,


                };



                terminatedemployee = await _terminatedemployeeRepository.AddAsync(terminatedemployee);

                await _employeeRepository.DeleteAsync(employeeToDelete);

                return Unit.Value;
            }
            catch (Exception ex) { return Unit.Value; }
        }

    }
}
