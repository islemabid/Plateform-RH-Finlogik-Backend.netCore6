using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Contracts.Persistance
{
    public interface IWorkingHoursSummaryRepository : IAsyncRepository<WorkingHoursSummary>

    {
        List<WorkingHoursSummary> GetWorkingHoursSummaryByIDEmployee(int IDEmployee);
        List<WorkingHoursSummary> GetAllWorkingHoursSummary();
        Task<WorkingHoursSummary> GetWorkingHoursSummaryByIDEmployee_Date(int IDEmployee, DateTime date);
    }
}
