using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.LeaveTypes.Queries.GetListLeaveType
{
    public class GetListLeaveTypeQueryHandler : IRequestHandler<GetListLeaveTypeQuery, List<LeaveTypeListVm>>
    {

        private readonly IAsyncRepository<LeaveType> _leavetypeRepository;
        private readonly IMapper _mapper;

        public GetListLeaveTypeQueryHandler(IMapper mapper, IAsyncRepository<LeaveType> leavetypeRepository)
        {
            _mapper = mapper;
            _leavetypeRepository = leavetypeRepository;
        }

        public async Task<List<LeaveTypeListVm>> Handle(GetListLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            var allLeaveTypes = (await _leavetypeRepository.GetAllAsync());
            return _mapper.Map<List<LeaveTypeListVm>>(allLeaveTypes);
        }
    }

}
