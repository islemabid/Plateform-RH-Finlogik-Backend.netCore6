using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{


    public class WorkingHoursSummaryRepository : BaseRepository<WorkingHoursSummary>, IWorkingHoursSummaryRepository
    {
        public WorkingHoursSummaryRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {
        }
        public List<WorkingHoursSummary> GetAllWorkingHoursSummary()
        {
            return _dbContext.WorkingHoursSummarys.ToList();
        }
        public  List<WorkingHoursSummary> GetWorkingHoursSummaryByIDEmployee(int IDEmployee)
        {
           return  _dbContext.WorkingHoursSummarys.Where(x => x.IdEmployee == IDEmployee).ToList();
        }

        public async Task<WorkingHoursSummary> GetWorkingHoursSummaryByIDEmployee_Date(int IDEmployee, DateTime date)
        {
            return _dbContext.WorkingHoursSummarys.Where(x => x.IdEmployee == IDEmployee && x.date.Day == date.Day).FirstOrDefault();

        }
    }
}
