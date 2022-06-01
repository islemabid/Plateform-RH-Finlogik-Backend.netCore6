using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Contrats.Queries.GetContratsList
{
    public  class GetContratsListQueryHandler : IRequestHandler<GetContratsListQuery, List<ContratsListVm>>
    {
        private readonly IAsyncRepository<Contrat> _contratRepository;
        private readonly IMapper _mapper;

        public GetContratsListQueryHandler(IMapper mapper, IAsyncRepository<Contrat> contratRepository)
        {
            _mapper = mapper;
            _contratRepository = contratRepository;
        }

        public async Task<List<ContratsListVm>> Handle(GetContratsListQuery request, CancellationToken cancellationToken)
        {
            var allcontrats = (await _contratRepository.GetAllAsync()).OrderByDescending(x=>x.Id);
            return _mapper.Map<List<ContratsListVm>>(allcontrats);
        }

    }
    
}
