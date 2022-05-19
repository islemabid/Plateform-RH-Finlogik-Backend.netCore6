

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Command.CancelTimeOffBalances
{
    public class CancelTimeOffBalancesCommand : IRequest
    {
        public int Id { get; set; }


    }

}
