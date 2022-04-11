using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationMessage
{
    public class GetNotificationMessageQuery:IRequest<List<NotificationResult>>
    {
    }
}
