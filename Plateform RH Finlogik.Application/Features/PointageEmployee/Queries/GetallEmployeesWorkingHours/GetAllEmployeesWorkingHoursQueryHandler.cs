



using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetallEmployeesWorkingHours
{
    public class GetAllEmployeesWorkingHoursQueryHandler : IRequestHandler<GetAllEmployeesWorkingHoursQuery, List<WorkingHoursOfAllEmployees>>
    {

        private readonly IWorkingHoursSummaryRepository _workingHoursSummaryRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesWorkingHoursQueryHandler(IEmployeeRepository employeeRepository, IWorkingHoursSummaryRepository workingHoursSummaryRepository, IPointageRepository pointageRepository)
        {

            _employeeRepository = employeeRepository;

            _workingHoursSummaryRepository = workingHoursSummaryRepository;

        }

        public async Task<List<WorkingHoursOfAllEmployees>> Handle(GetAllEmployeesWorkingHoursQuery request, CancellationToken cancellationToken)
        {

            List<WorkingHoursSummary> allWorkingHours = _workingHoursSummaryRepository.GetAllWorkingHoursSummary();
            List<WorkingHoursOfAllEmployees> workingHours = new List<WorkingHoursOfAllEmployees>();
            foreach (WorkingHoursSummary s in allWorkingHours)
            {
                WorkingHoursOfAllEmployees workHours = new WorkingHoursOfAllEmployees()
                {
                    id = s.id,
                    date = s.date,
                    hours = s.hours,
                    IdEmployee = s.IdEmployee,
                    EmployeeFullName = (await _employeeRepository.GetByIDAsync(s.IdEmployee)).FirstName + " " + (await _employeeRepository.GetByIDAsync(s.IdEmployee)).LastName
                };
                workingHours.Add(workHours);
            }
            return workingHours;
        }

    }
}
  

