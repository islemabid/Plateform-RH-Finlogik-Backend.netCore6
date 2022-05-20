
using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetAllWorkingHoursByIDEmployee
{
    public class GetAllWorkingHoursByIDEmployeeQuery : IRequest<List<AllWorkingHoursOfEmployeeVm>>
    {
        public int IdEmployee { get; set; }
    }
}
