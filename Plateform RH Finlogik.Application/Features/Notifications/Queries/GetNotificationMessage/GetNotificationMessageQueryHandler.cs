using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;


namespace Plateform_RH_Finlogik.Application.Features.Notifications.Queries.GetNotificationMessage
{
    public class GetNotificationMessageQueryHandler : IRequestHandler<GetNotificationMessageQuery, List<NotificationResult>>
    {
     
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetNotificationMessageQueryHandler(IMapper mapper,INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async  Task<List<NotificationResult>> Handle(GetNotificationMessageQuery request, CancellationToken cancellationToken)
        {
            var results = await  _notificationRepository.GetNotificationMessage();
            return _mapper.Map<List<NotificationResult>>(results);
            

        }
    }
}
