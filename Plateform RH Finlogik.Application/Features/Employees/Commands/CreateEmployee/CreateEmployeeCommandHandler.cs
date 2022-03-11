using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            
        }

        

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Adress = request.Adress,
                Cin = request.Cin,
                PersonnelEmail = request.PersonnelEmail,
                WorkEmail = request.WorkEmail,
                WorkPhone = request.WorkPhone,
                IdRole = request.IdRole,
                ImageUrl = request.ImageUrl,
                BirthDate = request.BirthDate,
                City = request.City,
                Contry = request.Contry,
                CNSSNumber = request.CNSSNumber,
                ContratType = request.ContratType,
                postalCode = request.postalCode,
                Region = request.Region,
                Diplome = request.Diplome,
                Password = request.Password,
                PersonnelPhone = request.PersonnelPhone,
                HoursPerWeek = request.HoursPerWeek,
                Gender = request.Gender,


            };

            employee = await _employeeRepository.AddAsync(employee);
            EmployeeDto @employeeDTo = _mapper.Map<EmployeeDto>(employee);
            return @employeeDTo;

        }
    }
}
