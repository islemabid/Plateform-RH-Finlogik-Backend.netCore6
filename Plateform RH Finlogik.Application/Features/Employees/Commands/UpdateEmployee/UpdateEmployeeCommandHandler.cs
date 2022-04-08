using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.UpdateEmployee
  
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;

        private readonly IEmployeePostRepository _employeePostRepository;

        private readonly IHistoryContratRepository _historyContratRepository;


        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository, IEmployeePostRepository employeePostRepository , IHistoryContratRepository historyContratRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeePostRepository = employeePostRepository;
            _historyContratRepository = historyContratRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employeeToUpdate = await _employeeRepository.GetByIDAsync(request.Id);

            if (employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

           

            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));

            await _employeeRepository.UpdateAsync(employeeToUpdate);

            List<EmployeePost> allPostsByEmployeeID = _employeePostRepository.GetAllEmployeesPostsByEmployeeID(request.Id).Where(a => a.isActive == true).ToList();

            EmployeePost samePost = allPostsByEmployeeID.FirstOrDefault(a => a.IdPost == request.IdPost);

            if (samePost == null)
            {
                foreach (EmployeePost p in allPostsByEmployeeID)
                {
                    p.isActive = false;
                    await _employeePostRepository.UpdateAsync(p);
                }

                var employeePost = new EmployeePost
                {
                    IdEmployee = request.Id,
                    IdPost = request.IdPost,
                    StartDate = DateTime.Now,
                    isActive = true

                };
                await _employeePostRepository.AddAsync(employeePost);

            }



            List<HistoryContrat> allHistoryContratByEmployeeID = _historyContratRepository.GetAllHistoryContratByEmployeeID(request.Id).Where(a => a.isActive == true).ToList();
            HistoryContrat sameContrat = allHistoryContratByEmployeeID.FirstOrDefault(a => a.IdContrat == request.IdContrat);



            if (sameContrat == null)
            {
                foreach (HistoryContrat h in allHistoryContratByEmployeeID)
                {
                  
                        h.isActive = false;
                        await _historyContratRepository.UpdateAsync(h);
                    
                }

                var historyContrat = new HistoryContrat
                {
                    IdEmployee = request.Id,
                    IdContrat = request.IdContrat,
                    StartDate = DateTime.Now,
                    isActive = true

                };
                await _historyContratRepository.AddAsync(historyContrat);


            }

            return Unit.Value;
        }

    }
}
