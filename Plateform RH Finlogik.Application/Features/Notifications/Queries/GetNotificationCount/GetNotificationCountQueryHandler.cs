using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationCount
{
    public class GetNotificationCountQueryHandler : IRequestHandler<GetNotificationCountQuery, NotificationCountResult>
    {
       
        private readonly INotificationRepository _notificationRepository;
  
         public GetNotificationCountQueryHandler (INotificationRepository notificationRepository)
        {
        
            _notificationRepository = notificationRepository;
        }
        public async Task<NotificationCountResult> Handle(GetNotificationCountQuery request, CancellationToken cancellationToken)
        {
            var @Count  = await _notificationRepository.GetNotificationCount();

            NotificationCountResult notif = new NotificationCountResult()
            {
                Count = @Count
            };
            
            return notif;


        }
    }
}
