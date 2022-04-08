using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features.HubClient;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Candidats.Commands.CreateCandidat
{
    public class CreateCandidatCommandHandler : IRequestHandler<CreateCandidatCommand, int>
    {
        private readonly ICandidatRepository _candidatRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public CreateCandidatCommandHandler(IMapper mapper, ICandidatRepository candidatRepository, IHubContext<BroadcastHub, IHubClient> hubContext, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _candidatRepository = candidatRepository;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;

        }

        public async Task<int> Handle(CreateCandidatCommand request, CancellationToken cancellationToken)
        {
            var @candidat = _mapper.Map<Candidat>(request);
            @candidat = await _candidatRepository.AddAsync(candidat);
            Notification notification = new Notification()
            {
                NameCandidat = candidat.FirstName,

            };
            _notificationRepository.AddAsync(notification);
            await _hubContext.Clients.All.BroadcastMessage();
        
            return @candidat.Id;

        }
    }
}
