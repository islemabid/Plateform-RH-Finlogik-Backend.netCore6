using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Contrats.Commands.DeleteContrat
{
    public class DeleteContratCommandHandler : IRequestHandler<DeleteContratCommand>
    {
        private readonly IAsyncRepository<Contrat> _contratRepository;
        private readonly IMapper _mapper;

        public DeleteContratCommandHandler(IMapper mapper, IAsyncRepository<Contrat> contratRepository)
        {
            _mapper = mapper;
            _contratRepository = contratRepository;
        }

        public async Task<Unit> Handle(DeleteContratCommand request, CancellationToken cancellationToken)
        {
            var contratToDelete = await _contratRepository.GetByIDAsync(request.Id);

            if (contratToDelete == null)
            {
                throw new NotFoundException(nameof(Contrat), request.Id);
            }

            await _contratRepository.DeleteAsync(contratToDelete);

            return Unit.Value;
        }

    }

}

