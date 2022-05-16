

using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class HolidayRepository : BaseRepository<Holidays>, IHolidayRepository
    {
        public HolidayRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {
        }
   
    }
}
