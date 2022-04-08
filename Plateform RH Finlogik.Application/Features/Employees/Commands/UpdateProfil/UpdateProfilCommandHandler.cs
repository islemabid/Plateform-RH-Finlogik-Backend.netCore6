using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateProfil
{
    public class UpdateProfilCommandHandler : IRequestHandler<UpdateProfilCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateProfilCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
           
        }


        public async  Task<Unit> Handle(UpdateProfilCommand request , CancellationToken cancellationToken)
        {
            var employeeProfilToUpdate = await _employeeRepository.GetByIDAsync(request.Id);

            if (employeeProfilToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }



            _mapper.Map(request, employeeProfilToUpdate, typeof(UpdateProfilCommandHandler), typeof(Employee));

            await _employeeRepository.UpdateAsync(employeeProfilToUpdate);


            return Unit.Value;
        }
    }
}


