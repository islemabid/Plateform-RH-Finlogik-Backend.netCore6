using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IMapper mapper, IAsyncRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            var roleToUpdate = await _roleRepository.GetByIDAsync(request.Id);

            if (roleToUpdate == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }



            _mapper.Map(request, roleToUpdate, typeof(UpdateRoleCommand), typeof(Role));

            await _roleRepository.UpdateAsync(roleToUpdate);

            return Unit.Value;
        }

    }
}

