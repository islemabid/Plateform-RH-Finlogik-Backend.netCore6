using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features.HubClient;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationMessage
{
    public class GetNotificationMessageQueryHandler : IRequestHandler<GetNotificationMessageQuery, List<NotificationResult>>
    {
     
        private readonly INotificationRepository _notificationRepository;

        public GetNotificationMessageQueryHandler(INotificationRepository notificationRepository)
        {
            
            _notificationRepository = notificationRepository;
        }

        public Task<List<NotificationResult>> Handle(GetNotificationMessageQuery request, CancellationToken cancellationToken)
        {
            var results = _notificationRepository.GetNotificationMessage();
            return results;

        }
    }
}
