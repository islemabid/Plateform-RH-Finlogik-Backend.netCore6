using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.LeaveTypes.Queries.GetListLeaveType
{
    public class GetListLeaveTypeQuery : IRequest<List<LeaveTypeListVm>>
    {
    }
}
