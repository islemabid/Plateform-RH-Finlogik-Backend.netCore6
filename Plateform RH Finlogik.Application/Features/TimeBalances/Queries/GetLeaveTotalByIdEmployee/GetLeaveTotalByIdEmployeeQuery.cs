using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetLeaveTotalByIdEmployee
{
    public  class GetLeaveTotalByIdEmployeeQuery : IRequest<LeaveTotalByIdEmployeeVm>
    {
        public int IdEmployee { get; set; }
    }
}
