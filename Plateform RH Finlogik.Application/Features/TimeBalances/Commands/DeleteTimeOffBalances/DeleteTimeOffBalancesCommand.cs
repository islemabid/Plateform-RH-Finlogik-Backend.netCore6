using MediatR;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.DeleteTimeOffBalances
{
    public class DeleteTimeOffBalancesCommand : IRequest
    {
        public int Id { get; set; }


    }
}
