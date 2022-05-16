

using MediatR;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetEmployeePointage
{
    public  class GetEmployeePointageQuery : IRequest<EmployeePointageVm>
    {
        public int idEmployee { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
