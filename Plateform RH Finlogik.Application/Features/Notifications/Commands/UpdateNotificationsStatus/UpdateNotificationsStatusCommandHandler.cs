

using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.Notifications.Commands.UpdateNotificationsStatus
{
    public class UpdateNotificationsStatusCommandHandler : IRequestHandler<UpdateNotificationsStatusCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public UpdateNotificationsStatusCommandHandler(IMapper mapper, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<Unit> Handle(UpdateNotificationsStatusCommand request, CancellationToken cancellationToken)
        {
            var notificationResult = await _notificationRepository.GetByIDAsync(request.id);
            if (notificationResult == null)
            {
                throw new NotFoundException(nameof(Notification), request.id);
            }
            if (notificationResult.Status == true) {
                notificationResult.Status = false;

                _mapper.Map(request, notificationResult, typeof(UpdateNotificationsStatusCommand), typeof(Notification));

                await _notificationRepository.UpdateAsync(notificationResult);

                return Unit.Value;
            }
            else
            {
                return Unit.Value;
            }
          
        }
    }
}
