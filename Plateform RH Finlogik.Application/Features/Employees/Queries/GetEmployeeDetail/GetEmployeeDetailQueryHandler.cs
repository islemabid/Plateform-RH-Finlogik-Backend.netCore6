using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailVm>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeDetailQueryHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
         
        }

        public async Task<EmployeeDetailVm> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var @employee = await _employeeRepository.GetByIDAsync(request.Id);
            var employeeDetailDto = _mapper.Map<EmployeeDetailVm>(@employee);
            return employeeDetailDto;

        }
    }

}
