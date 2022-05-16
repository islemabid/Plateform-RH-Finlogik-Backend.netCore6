

using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Application.Contracts.Persistance
{
    public interface IPointageRepository : IAsyncRepository<Pointage>
    {
         Task<Pointage> GetPointageByIDEmployee(int IDEmployee, DateTime date);
    }
}
