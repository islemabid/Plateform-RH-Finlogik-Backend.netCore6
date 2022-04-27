using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler <GetEmployeesListQuery, List<EmployeeListVm>>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IEmployeePostRepository _employeePostRepository;
        private readonly IHistoryContratRepository _historyContratRepository;


        public GetEmployeesListQueryHandler(IAsyncRepository<Employee> employeeRepository, IEmployeePostRepository employeePostRepository, IHistoryContratRepository historyContratRepository)
        {
           
            _employeeRepository = employeeRepository;
            _employeePostRepository = employeePostRepository;
            _historyContratRepository = historyContratRepository;

        }

        public async Task<List<EmployeeListVm>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Employee> allEmployees = (await _employeeRepository.GetAllAsync()).Where(x => x.isActive == true).OrderBy(x => x.BirthDate);
            List <EmployeeListVm> employeeListVm = new List<EmployeeListVm>();
            foreach (Employee employee in allEmployees)
            {
                EmployeeListVm e = new EmployeeListVm()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Adress = employee.Adress,
                    Cin = employee.Cin,
                    PersonnelEmail = employee.PersonnelEmail,
                    WorkEmail = employee.WorkEmail,
                    WorkPhone = employee.WorkPhone,
                    IdRole = employee.IdRole,
                    ImageUrl = employee.ImageUrl,
                    BirthDate = employee.BirthDate,
                    City = employee.City,
                    Contry = employee.Contry,
                    CNSSNumber = employee.CNSSNumber,
                    postalCode = employee.postalCode,
                    Region = employee.Region,
                    Diplome = employee.Diplome,
                    Password = employee.Password,
                    PersonnelPhone = employee.PersonnelPhone,
                    HoursPerWeek = employee.HoursPerWeek,
                    Gender = employee.Gender,
                    IdDepartement = employee.IdDepartement,
                    IdPost = _employeePostRepository.GetCurrentPostByEmployeeID(employee.Id).Id,
                    Id = employee.Id,
                    IdContrat = _historyContratRepository.GetCurrentContratByEmployeeID(employee.Id).Id,
           
                };
                employeeListVm.Add(e);
                }
            return employeeListVm;
        }
    }
}
