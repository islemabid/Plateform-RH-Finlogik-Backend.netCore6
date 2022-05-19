using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features.HubClient;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Commands.CreateTimeOffBalances
{
    public class CreateTimeOffBalancesCommandHandler : IRequestHandler<CreateTimeOffBalancesCommand, int>
    {
        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public CreateTimeOffBalancesCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, ItimeoffBalancesRepository timeoffbalanceRepository, IHubContext<BroadcastHub, IHubClient> hubContext, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _timeoffbalanceRepository = timeoffbalanceRepository;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;
            _employeeRepository = employeeRepository;
           
    }

        public async Task<int> Handle(CreateTimeOffBalancesCommand request, CancellationToken cancellationToken)
        {
            var @timeoffbalance= _mapper.Map<TimeOffBalances>(request);

            @timeoffbalance = await _timeoffbalanceRepository.AddAsync(@timeoffbalance);

            Notification notification = new Notification()
            {
                Message = (await _employeeRepository.GetByIDAsync(request.IdEmployee)).FirstName+""+ (await _employeeRepository.GetByIDAsync(request.IdEmployee)).LastName+" "+"passed a conge",
                Status = true

            };
            _notificationRepository.AddAsync(notification);
            await _hubContext.Clients.All.BroadcastMessage();
            return @timeoffbalance.Id;

        }

    }
}
