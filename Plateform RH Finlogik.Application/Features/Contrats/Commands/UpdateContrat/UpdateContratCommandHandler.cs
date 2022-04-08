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

namespace Plateform_RH_Finlogik.Application.Features.Contrats.Commands.UpdateContrat
{
    public class UpdateContratCommandHandler : IRequestHandler<UpdateContratCommand>
    {
        private readonly IAsyncRepository<Contrat> _contratRepository;
        private readonly IMapper _mapper;

        public UpdateContratCommandHandler(IMapper mapper, IAsyncRepository<Contrat> contratRepository)
        {
            _mapper = mapper;
            _contratRepository = contratRepository;
        }

        public async Task<Unit> Handle(UpdateContratCommand request, CancellationToken cancellationToken)
        {

            var contratToUpdate = await _contratRepository.GetByIDAsync(request.Id);

            if (contratToUpdate == null)
            {
                throw new NotFoundException(nameof(Contrat), request.Id);
            }



            _mapper.Map(request, contratToUpdate, typeof(UpdateContratCommand), typeof(Contrat));

            await _contratRepository.UpdateAsync(contratToUpdate);

            return Unit.Value;
        }

    }
}



