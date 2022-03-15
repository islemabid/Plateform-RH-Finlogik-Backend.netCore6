using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance
{
    public class PlateformRHDbcontext : DbContext
    {
        public PlateformRHDbcontext(DbContextOptions<PlateformRHDbcontext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TerminatedEmployee> TermiantedEmployees{ get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
