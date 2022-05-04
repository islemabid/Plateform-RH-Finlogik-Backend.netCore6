using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.LeaveBalances.Queries.GetLeaveBalncesByIDEmpoyee_IDLeaveType
{
    public class GetLeaveBalncesByIDEmpoyee_IDLeaveTypeQueryHandler : IRequestHandler<GetLeaveBalncesByIDEmpoyee_IDLeaveTypeQuery, LeaveBalancesVm>
    {
        private readonly ILeaveBalancesRepository _LeaveBalancesRepository;
        private readonly IMapper _mapper;

        public GetLeaveBalncesByIDEmpoyee_IDLeaveTypeQueryHandler(IMapper mapper, ILeaveBalancesRepository LeaveBalancesRepository)
        {
            _mapper = mapper;
            _LeaveBalancesRepository = LeaveBalancesRepository;

        }

        public async Task<LeaveBalancesVm> Handle(GetLeaveBalncesByIDEmpoyee_IDLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            var @leaveBalance = await _LeaveBalancesRepository.GetLeaveBalanceByIDEmployee_IDLeaveType(request.IdEmployee,request.IdLeaveType);
            var leaveBalanceDetail = _mapper.Map<LeaveBalancesVm>(@leaveBalance);
            return leaveBalanceDetail;

        }

    }
}
