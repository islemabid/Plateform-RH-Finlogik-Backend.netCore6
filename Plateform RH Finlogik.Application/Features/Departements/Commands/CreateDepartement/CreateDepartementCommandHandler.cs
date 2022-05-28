using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Departements.Commands.CreateDepartement
{
    public class CreateDepartementCommandHandler : IRequestHandler<CreateDepartementCommand, int>
    {
        private readonly IDepartementRepository _departementRepository;
        private readonly IMapper _mapper;
        public CreateDepartementCommandHandler(IMapper mapper, IDepartementRepository departementRepository)
        {
            _mapper = mapper;
            _departementRepository = departementRepository;

        }

        public async Task<int> Handle(CreateDepartementCommand request, CancellationToken cancellationToken)
        {
            if (request.LongDescription != "" && request.ShortDescription!="")
            {
                var @dep = _mapper.Map<Departement>(request);

                @dep = await _departementRepository.AddAsync(@dep);

                return @dep.Id;
            }
            else
            {
                throw new Exception($"failed");
            }

        }

    }
   
}
