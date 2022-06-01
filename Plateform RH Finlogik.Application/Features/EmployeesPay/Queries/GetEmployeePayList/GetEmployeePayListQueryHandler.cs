using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;


namespace Plateform_RH_Finlogik.Application.Features.EmployeesPay.Queries.GetEmployeePayList
{
    public class GetEmployeePayListQueryHandler:IRequestHandler<GetEmployeePayListQuery, List<EmployeePayListVm>>
    {

        private readonly IEmployeePayRepository _payRepository;
        private readonly IEmployeeRepository _employeeRepositroy;

    public GetEmployeePayListQueryHandler(IEmployeeRepository employeeRepositroy, IEmployeePayRepository payRepository)
    {
        _employeeRepositroy = employeeRepositroy;
        _payRepository = payRepository;
    }

    public async Task<List<EmployeePayListVm>> Handle(GetEmployeePayListQuery request, CancellationToken cancellationToken)
    {
        var allPays = (await _payRepository.GetAllAsync()).OrderByDescending(x=>x.Id);
        List<EmployeePayListVm> payrool = new List<EmployeePayListVm>();
        foreach(var pay in allPays)
            {
                EmployeePayListVm e = new EmployeePayListVm
                {
                    Id = pay.Id,
                    Year = pay.Year,
                    Mounth = pay.Mounth,
                    FixedSalary = pay.FixedSalary,
                    MealTicket = pay.MealTicket,
                    TicketPassGift = pay.TicketPassGift,
                    Prime = pay.Prime,
                    status = pay.status,
                    IdEmployee = pay.IdEmployee,
                    employeeFullName = _employeeRepositroy.GetByID(pay.IdEmployee).FirstName + "  " + _employeeRepositroy.GetByID(pay.IdEmployee).LastName,



                };
                payrool.Add(e);
            }

        return payrool;
    }
}
    
    }
