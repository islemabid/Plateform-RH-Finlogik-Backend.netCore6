
using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.Notifications.Commands.UpdateNotificationsStatus
{
    public class UpdateNotificationsStatusCommand : IRequest
    {
        public int id { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
