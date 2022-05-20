
using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetallEmployeesWorkingHours
{
    public class GetAllEmployeesWorkingHoursQuery : IRequest<List<WorkingHoursOfAllEmployees>>
    {
    }
}
