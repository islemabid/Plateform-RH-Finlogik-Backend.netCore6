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

namespace Plateform_RH_Finlogik.Application.Features.Departements.Commands.DeleteDepartement
{
    public class DeleteDepartementCommandHandler : IRequestHandler<DeleteDepartementCommand>
    {
        private readonly IAsyncRepository<Departement> _deptRepository;
        private readonly IMapper _mapper;

        public DeleteDepartementCommandHandler(IMapper mapper, IAsyncRepository<Departement> deptRepository)
        {
            _mapper = mapper;
            _deptRepository = deptRepository;
        }

        public async Task<Unit> Handle(DeleteDepartementCommand request, CancellationToken cancellationToken)
        {
            var depToDelete = await _deptRepository.GetByIDAsync(request.Id);

            if (depToDelete == null)
            {
                throw new NotFoundException(nameof(Departement), request.Id);
            }

            await _deptRepository.DeleteAsync(depToDelete);

            return Unit.Value;
        }

    }
   
}
