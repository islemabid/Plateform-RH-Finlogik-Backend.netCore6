

using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetEmployeePointage
{
    public class EmployeePointageVm
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public int idEmployee { get; set; }

        public Employee employe { get; set; }

        public float workingNumbersHours { get; set; }

        public float UserNumbersHours { get; set; }
    }
}
