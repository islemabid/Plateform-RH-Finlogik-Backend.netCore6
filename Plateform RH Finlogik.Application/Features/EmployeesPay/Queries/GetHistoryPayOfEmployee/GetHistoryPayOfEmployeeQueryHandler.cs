using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetHistoryPayOfEmployee
{
    public class GetHistoryPayOfEmployeeQueryHandler : IRequestHandler<GetHistoryPayOfEmployeeQuery, List<HistoryPayVm>>
    {
        private readonly IEmployeePayRepository _employeePayRepository;
        private readonly IMapper _mapper;

        public GetHistoryPayOfEmployeeQueryHandler(IMapper mapper, IEmployeePayRepository employeePayRepository)
        {
            _mapper = mapper;
            _employeePayRepository = employeePayRepository;
        }

        public async Task<List<HistoryPayVm>> Handle(GetHistoryPayOfEmployeeQuery request, CancellationToken cancellationToken)
        {
           
             var   allEmployeePaysByEmployeeID = _employeePayRepository.GetHistoryPayOfEmployee(request.IdEmployee);
            return _mapper.Map<List<HistoryPayVm>>(allEmployeePaysByEmployeeID);
        }

    }
}

