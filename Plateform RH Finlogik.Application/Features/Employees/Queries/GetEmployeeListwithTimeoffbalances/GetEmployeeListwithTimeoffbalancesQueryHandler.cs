using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeListwithTimeoffbalances
{
    public class GetEmployeeListwithTimeoffbalancesQueryHandler : IRequestHandler<GetEmployeeListwithTimeoffbalancesQuery, List<EmployeeTimeoffbalancesListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListwithTimeoffbalancesQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeTimeoffbalancesListVm>> Handle(GetEmployeeListwithTimeoffbalancesQuery request, CancellationToken cancellationToken)
        {
            var list = await _employeeRepository.GetEmployeeWithTimeOffBalances();
            return _mapper.Map<List<EmployeeTimeoffbalancesListVm>>(list);
        }
    }

    
}
