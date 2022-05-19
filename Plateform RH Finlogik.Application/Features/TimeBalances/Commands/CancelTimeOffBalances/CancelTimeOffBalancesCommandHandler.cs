

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Features.HubClient;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Command.CancelTimeOffBalances
{
    public class CancelTimeOffBalancesCommandHandler : IRequestHandler<CancelTimeOffBalancesCommand>
    {

        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public CancelTimeOffBalancesCommandHandler(IMapper mapper, ItimeoffBalancesRepository timeoffbalanceRepository, IEmployeeRepository employeeRepository, IHubContext<BroadcastHub, IHubClient> hubContext, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;
            _employeeRepository = employeeRepository;

        }
        public async Task<Unit> Handle(CancelTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {
            var timeoffbalancesToCancel = await _timeoffbalanceRepository.GetByIDAsync(request.Id);

            if (timeoffbalancesToCancel == null)
            {
                throw new NotFoundException(nameof(TimeOffBalances), request.Id);
            }
            if (timeoffbalancesToCancel.State == "Waiting")
            {
                Notification notification = new Notification()
                {
                    Message = (await _employeeRepository.GetByIDAsync(timeoffbalancesToCancel.IdEmployee)).FirstName + " " + (await _employeeRepository.GetByIDAsync(timeoffbalancesToCancel.IdEmployee)).LastName + " " + " demande to cancel a conge",
                    Status = true

                };
                _notificationRepository.AddAsync(notification);
                await _hubContext.Clients.All.BroadcastMessage();

                return Unit.Value;
            }
            if (timeoffbalancesToCancel.State == "validated")
            {
                if (timeoffbalancesToCancel.StartDate > DateTime.Now)
                {
                    Notification notification = new Notification()
                    {
                        Message = (await _employeeRepository.GetByIDAsync(timeoffbalancesToCancel.IdEmployee)).FirstName + " " + (await _employeeRepository.GetByIDAsync(timeoffbalancesToCancel.IdEmployee)).LastName + " " + " demande to cancel a conge",
                        Status = true

                    };
                    _notificationRepository.AddAsync(notification);
                    await _hubContext.Clients.All.BroadcastMessage();

                    return Unit.Value;
                }

            }
            return Unit.Value;
        }
    }
}