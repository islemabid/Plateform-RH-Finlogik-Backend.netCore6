using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Candidats.Commands.CreateCandidat
{
    public class CreateCandidatCommandHandler : IRequestHandler<CreateCandidatCommand, int>
    {
        private readonly ICandidatRepository _candidatRepository;
        private readonly IMapper _mapper;
 
        public CreateCandidatCommandHandler(IMapper mapper, ICandidatRepository candidatRepository)
        {
            _mapper = mapper;
            _candidatRepository = candidatRepository;
           

        }

        public async Task<int> Handle(CreateCandidatCommand request, CancellationToken cancellationToken)
        {
            
          
            var @candidat = _mapper.Map<Candidat>(request);
            @candidat = await _candidatRepository.AddAsync(candidat);
            return @candidat.Id;

        }
    }
}
