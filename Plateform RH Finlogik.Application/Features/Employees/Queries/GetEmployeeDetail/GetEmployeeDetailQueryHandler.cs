using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using BC = BCrypt.Net.BCrypt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plateform_RH_Finlogik.Application.Helpers;

namespace Plateform_RH_Finlogik.Application.Features.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailVm>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IEmployeePostRepository _employeePostRepository;
        private readonly IHistoryContratRepository _historyContratRepository;
        private readonly IMapper _mapper;

        public GetEmployeeDetailQueryHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository, IEmployeePostRepository employeePostRepository, IHistoryContratRepository historyContratRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeePostRepository = employeePostRepository;
            _historyContratRepository = historyContratRepository;

        }

        public async Task<EmployeeDetailVm> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {

            var @employee = await _employeeRepository.GetByIDAsync(request.Id);
            string t = Helper.Decrypt(employee.Password);
            return new EmployeeDetailVm()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Adress = employee.Adress,
                Cin = employee.Cin,
                PersonnelEmail = employee.PersonnelEmail,
                WorkEmail = employee.WorkEmail,
                WorkPhone = employee.WorkPhone,
                IdRole = employee.IdRole,
                ImageUrl = employee.ImageUrl,
                BirthDate = employee.BirthDate,
                City = employee.City,
                Contry = employee.Contry,
                CNSSNumber = employee.CNSSNumber,
                postalCode = employee.postalCode,
                Region = employee.Region,
                Diplome = employee.Diplome,
                Password = Helper.Decrypt( employee.Password),
                PersonnelPhone = employee.PersonnelPhone,
                HoursPerWeek = employee.HoursPerWeek,
                Gender = employee.Gender,
                IdDepartement = employee.IdDepartement,
                Post = _employeePostRepository.GetCurrentPostByEmployeeID(request.Id),
                Id = employee.Id,
                Contrat =_historyContratRepository.GetCurrentContratByEmployeeID(request.Id) 

            };
    }
    }
}


