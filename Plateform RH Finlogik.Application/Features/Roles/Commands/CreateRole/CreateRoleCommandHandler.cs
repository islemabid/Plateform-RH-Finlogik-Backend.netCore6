using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public CreateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;

        }

        public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var @role = _mapper.Map<Role>(request);

            @role = await _roleRepository.AddAsync(@role);



            return @role.Id;

        }

    }
}
