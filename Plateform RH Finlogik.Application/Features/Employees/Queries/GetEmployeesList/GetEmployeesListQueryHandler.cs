using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeesList
{
    internal class GetEmployeesListQueryHandler : IRequestHandler <GetEmployeesListQuery, List<EmployeeListVm>>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeListVm>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = (await _employeeRepository.GetAllAsync()).OrderBy(x => x.BirthDate);
            return _mapper.Map<List<EmployeeListVm>>(allEmployees);
        }
    }
}
