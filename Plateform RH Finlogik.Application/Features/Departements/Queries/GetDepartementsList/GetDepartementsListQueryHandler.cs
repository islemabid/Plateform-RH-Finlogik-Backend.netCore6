using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Departements.Queries.GetDepartementsList
{
    public class GetDepartementsListQueryHandler : IRequestHandler<GetDepartementsListQuery, List<DepartementsListVm>>
    {
        private readonly IAsyncRepository<Departement> _departementRepository;
        private readonly IMapper _mapper;

        public GetDepartementsListQueryHandler(IMapper mapper, IAsyncRepository<Departement> departementRepository)
        {
            _mapper = mapper;
            _departementRepository = departementRepository;
        }

        public async Task<List<DepartementsListVm>> Handle(GetDepartementsListQuery request, CancellationToken cancellationToken)
        {
            var allDepartements = (await _departementRepository.GetAllAsync()).OrderByDescending(x=>x.Id);
            return _mapper.Map<List<DepartementsListVm>>(allDepartements);
        }

    }

}
