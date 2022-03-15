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

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.AffecterEmployeePost
{
    public class AffectEmployeePostCommandHandler : IRequestHandler<AffectEmployeePostCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public AffectEmployeePostCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(AffectEmployeePostCommand request, CancellationToken cancellationToken)
        {

            var employeeToUpdate = await _employeeRepository.GetByIDAsync(request.Id);

            if (employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }
            employeeToUpdate.IdPost = request.IdPost;
            await _employeeRepository.UpdateAsync(employeeToUpdate);

            return Unit.Value;
        }

    }
}


