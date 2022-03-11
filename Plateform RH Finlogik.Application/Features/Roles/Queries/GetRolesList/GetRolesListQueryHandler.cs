using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, List<RolesListVm>>
    {
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public GetRolesListQueryHandler(IMapper mapper, IAsyncRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<List<RolesListVm>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var allroles = (await _roleRepository.GetAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<RolesListVm>>(allroles);
        }

    }
}
