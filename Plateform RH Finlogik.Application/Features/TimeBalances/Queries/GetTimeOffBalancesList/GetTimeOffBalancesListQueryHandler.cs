
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;


namespace Plateform_RH_Finlogik.Application.Features.TimeBalances.Queries.GetTimeOffBalancesList
{
    public class GetTimeOffBalancesListQueryHandler : IRequestHandler<GetTimeOffBalancesListQuery, List<TimeoffBalancesListVm>>
    {

        private readonly ItimeoffBalancesRepository _timeoffbalanceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public GetTimeOffBalancesListQueryHandler( ItimeoffBalancesRepository timeoffbalanceRepository, IEmployeeRepository employeeRepository)
        {
            
            _timeoffbalanceRepository = timeoffbalanceRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<TimeoffBalancesListVm>> Handle(GetTimeOffBalancesListQuery request, CancellationToken cancellationToken)
        {
           
            var allTimeoffBalances= (await _timeoffbalanceRepository.Getall()).Where(x=>x.IsActive==true);
            List<TimeoffBalancesListVm> timeoffBalancesListVm = new List<TimeoffBalancesListVm>();
            foreach (var timeoffBalance in allTimeoffBalances)
            {

                TimeoffBalancesListVm t = new TimeoffBalancesListVm()
                {
                    Id = timeoffBalance.Id,
                    StartDate = timeoffBalance.StartDate,
                    EndDate = timeoffBalance.EndDate,
                    IsActive = timeoffBalance.IsActive,
                    IdEmployee = timeoffBalance.IdEmployee,
                    Employee = new EmployeeVm()
                    {
                        FirstName = _employeeRepository.GetByID(timeoffBalance.IdEmployee).FirstName,
                        LastName = _employeeRepository.GetByID(timeoffBalance.IdEmployee).LastName,
                        Cin = _employeeRepository.GetByID(timeoffBalance.IdEmployee).Cin,
                        WorkEmail = _employeeRepository.GetByID(timeoffBalance.IdEmployee).WorkEmail

                    },
                    Comment = timeoffBalance.Comment,
                    IdLeaveType = timeoffBalance.IdLeaveType,
                    LeaveTypes = timeoffBalance.LeaveType,
                    state = timeoffBalance.State,
                    StartDateQuantity = timeoffBalance.StartDateQuantity,
                    EndDateQuantity = timeoffBalance.EndDateQuantity,


                };
                timeoffBalancesListVm.Add(t);

                }
            
              return timeoffBalancesListVm;
        }


    }
}
