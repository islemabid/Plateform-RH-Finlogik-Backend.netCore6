
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Plateform_RH_Finlogik.Application.Contracts.Interfaces;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Features.HubClient;
using Plateform_RH_Finlogik.Domain.Entities;



namespace Plateform_RH_Finlogik.Application.Features.ApplicationOffers.Commands.CreateApplicationOffer
{
    public class CreateApplicationOfferCommandHandler    : IRequestHandler<CreateApplicationOfferCommand, int>
    {
        private readonly IApplicationOfferRepository _applicationOffer;
        private readonly ICandidatRepository _candidatRepository;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
   
    
        public CreateApplicationOfferCommandHandler(IMapper mapper,IApplicationOfferRepository applicationOfferRepository, ICandidatRepository candidatRepository, IHubContext<BroadcastHub, IHubClient> hubContext, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _applicationOffer = applicationOfferRepository;
            _candidatRepository = candidatRepository;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;

        }

        public async Task<int> Handle(CreateApplicationOfferCommand request, CancellationToken cancellationToken)
        {




            var @applicationOffer = _mapper.Map<ApplicationOffer>(request);
            @applicationOffer = await _applicationOffer.AddAsync(applicationOffer);
            Notification notification = new Notification()
            {
                NameCandidat = (await _candidatRepository.GetByIDAsync(request.IdCandidat)).FirstName+""+ (await _candidatRepository.GetByIDAsync(request.IdCandidat)).LastName,
                Status = true

            };
            _notificationRepository.AddAsync(notification);

            await _hubContext.Clients.All.BroadcastMessage();
            return @applicationOffer.Id;
           

        }
    }
}

