using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using BC = BCrypt.Net.BCrypt;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeePostRepository _employeePostRepository;
        private readonly IHistoryContratRepository _historyContratRepository;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository , IEmployeePostRepository employeePostRepository, IHistoryContratRepository historyContratRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeePostRepository = employeePostRepository;
            _historyContratRepository = historyContratRepository;




        }

        

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Adress = request.Adress,
                Cin = request.Cin,
                PersonnelEmail = request.PersonnelEmail,
                WorkEmail = request.WorkEmail,
                WorkPhone = request.WorkPhone,
                IdRole = request.IdRole,
                ImageUrl = request.ImageUrl,
                BirthDate = request.BirthDate,
                City = request.City,
                Contry = request.Contry,
                CNSSNumber = request.CNSSNumber,
                postalCode = request.postalCode,
                Region = request.Region,
                Diplome = request.Diplome,
                Password = BC.HashPassword(request.Password),
                PersonnelPhone = request.PersonnelPhone,
                HoursPerWeek = request.HoursPerWeek,
                Gender = request.Gender,
                IdDepartement=request.IdDepartement,
               
            };

             await _employeeRepository.AddAsync(employee);

            var employeePost = new EmployeePost
            {
                IdEmployee = employee.Id,
                IdPost = request.IdPost,
                StartDate = DateTime.Now,
                isActive = true

            };

             await _employeePostRepository.AddAsync(employeePost);


            var employeeContrat = new HistoryContrat
            {
                IdEmployee = employee.Id,
                IdContrat = request.IdContrat,
                StartDate = DateTime.Now,
                EndDate=request.EndDate,
                isActive = true

            };

             await _historyContratRepository.AddAsync(employeeContrat);



            EmployeeDto @employeeDTo = _mapper.Map<EmployeeDto>(employee);
            return @employeeDTo;

        }
    }
}
