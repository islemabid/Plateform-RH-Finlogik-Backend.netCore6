using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public DeleteRoleCommandHandler(IMapper mapper, IAsyncRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var roleToDelete = await _roleRepository.GetByIDAsync(request.Id);

            if (roleToDelete == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }

            await _roleRepository.DeleteAsync(roleToDelete);

            return Unit.Value;
        }

    }

}
