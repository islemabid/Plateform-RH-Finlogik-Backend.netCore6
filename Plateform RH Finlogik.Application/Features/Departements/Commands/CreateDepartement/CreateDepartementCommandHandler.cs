using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var @dep = _mapper.Map<Departement>(request);

            @dep = await _departementRepository.AddAsync(@dep);



            return @dep.Id;

        }

    }
   
}
