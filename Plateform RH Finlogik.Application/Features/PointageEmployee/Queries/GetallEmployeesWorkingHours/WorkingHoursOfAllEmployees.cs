

namespace Plateform_RH_Finlogik.Application.Features.PointageEmployee.Queries.GetallEmployeesWorkingHours
{
    public class WorkingHoursOfAllEmployees
    {
        public int id { get; set; }

        public float hours { get; set; }

        public DateTime date { get; set; }

       
        public int IdEmployee { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
