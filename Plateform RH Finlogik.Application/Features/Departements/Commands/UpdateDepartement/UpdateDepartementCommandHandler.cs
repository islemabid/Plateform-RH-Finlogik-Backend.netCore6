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

namespace Plateform_RH_Finlogik.Application.Features.Departements.Commands.UpdateDepartement
{
    public class UpdateDepartementCommandHandler : IRequestHandler<UpdateDepartementCommand>
    {
        private readonly IAsyncRepository<Departement> _deptRepository;
        private readonly IMapper _mapper;

        public UpdateDepartementCommandHandler(IMapper mapper, IAsyncRepository<Departement> deptRepository)
        {
            _mapper = mapper;
            _deptRepository = deptRepository;
        }

        public async Task<Unit> Handle(UpdateDepartementCommand request, CancellationToken cancellationToken)
        {

            var depToUpdate = await _deptRepository.GetByIDAsync(request.Id);

            if (depToUpdate == null)
            {
                throw new NotFoundException(nameof(Departement), request.Id);
            }



            _mapper.Map(request, depToUpdate, typeof(UpdateDepartementCommand), typeof(Departement));

            await _deptRepository.UpdateAsync(depToUpdate);

            return Unit.Value;
        }

    }

}

