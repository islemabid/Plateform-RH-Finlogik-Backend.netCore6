

using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class PointageRepositroy : BaseRepository<Pointage>, IPointageRepository
    {
        public PointageRepositroy(PlateformRHDbcontext dbContext) : base(dbContext)
        {
        }
        public async Task<Pointage> GetPointageByIDEmployee(int IDEmployee, DateTime date)
        { 
            Pointage pointage =null;
            List<Pointage> lists = _dbContext.Set<Pointage>(). Where(a => a.IdEmployee == IDEmployee &&
                a.dateAction.Date == date.Date && a.action.Equals("In") && a.IsCalculated == false).OrderBy(a=>a.dateAction).ToList();
            if(lists.Count >0  && lists.Count==1)
            {
                lists[0].IsCalculated = true;
                _dbContext.Set<Pointage>().Update(lists[0]);
                _dbContext.SaveChanges();
                pointage= lists[0];
            }
            else
            { 
                foreach (Pointage p in lists)
                {
                    pointage = p;
                    p.IsCalculated = true;
                    _dbContext.Set<Pointage>().Update(p);
                    _dbContext.SaveChanges();

                }

            }
            return pointage;
            
    }
    }
}
