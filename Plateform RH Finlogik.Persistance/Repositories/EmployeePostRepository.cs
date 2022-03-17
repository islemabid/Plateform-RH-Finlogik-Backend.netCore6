using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class EmployeePostRepository : BaseRepository<EmployeePost>, IEmployeePostRepository
    {
        public EmployeePostRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {

        }

        public  List<EmployeePost> GetAllEmployeesPostsByEmployeeID(int id)
        {
            return  _dbContext.Set<EmployeePost>().Include(x => x.Post).Where(x => x.IdEmployee == id).ToList();
        }
    }

    }
