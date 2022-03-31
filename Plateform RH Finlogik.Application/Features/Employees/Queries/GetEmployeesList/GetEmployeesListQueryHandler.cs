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
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository, IEmployeePostRepository employeePostRepository, IHistoryContratRepository historyContratRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeePostRepository = employeePostRepository;
            _historyContratRepository = historyContratRepository;
        }

        public async Task<List<EmployeeListVm>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = (await _employeeRepository.GetAllAsync()).OrderBy(x => x.BirthDate);
            return _mapper.Map<List<EmployeeListVm>>(allEmployees);
        }
    }
}
