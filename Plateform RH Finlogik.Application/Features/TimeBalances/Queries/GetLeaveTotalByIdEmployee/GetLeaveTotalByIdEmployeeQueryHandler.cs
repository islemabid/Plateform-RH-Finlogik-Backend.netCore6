using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetLeaveTotalByIdEmployee
{
    public  class GetLeaveTotalByIdEmployeeQueryHandler : IRequestHandler<GetLeaveTotalByIdEmployeeQuery, LeaveTotalByIdEmployeeVm>
    {

        private readonly ILeaveBalancesRepository _leavebalanceRepository;
        private readonly IMapper _mapper;

        public GetLeaveTotalByIdEmployeeQueryHandler(IMapper mapper, ILeaveBalancesRepository leavebalanceRepository)
        {
            _mapper = mapper;
            _leavebalanceRepository = leavebalanceRepository;
        }

        public async Task<LeaveTotalByIdEmployeeVm> Handle(GetLeaveTotalByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            LeaveTotalByIdEmployeeVm leaveTotalByIdEmployeeVm = new LeaveTotalByIdEmployeeVm();
            LeaveBalance LeaveBalance = await _leavebalanceRepository.GetLeaveBalanceByIDEmployee_IDLeaveType(request.IdEmployee, 2);

            leaveTotalByIdEmployeeVm.numbertotalPaidLeave = LeaveBalance.numberDays;

            LeaveBalance = await _leavebalanceRepository.GetLeaveBalanceByIDEmployee_IDLeaveType(request.IdEmployee, 1);

            leaveTotalByIdEmployeeVm.numbertotalSickLeave = LeaveBalance.numberDays;
            return _mapper.Map<LeaveTotalByIdEmployeeVm>(leaveTotalByIdEmployeeVm);
        }


    }
}
