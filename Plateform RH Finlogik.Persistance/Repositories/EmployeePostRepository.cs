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
            return  _dbContext.Set<EmployeePost>().Include("Post").Include("Employee").Where(x => x.IdEmployee == id).ToList();
        }
        public Post GetCurrentPostByEmployeeID(int id)
        {
            List<EmployeePost> lists= _dbContext.Set<EmployeePost>().Include("Post").Include("Employee").Where(x => x.IdEmployee == id).ToList();
            foreach(EmployeePost post in lists)
            {
                if (post.isActive == true)
                {

                    return post.Post;
                }
            }
            return null;
        }
    }

    }
