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
        public DbSet<Post> Posts { get; set; }
        public DbSet<EmployeePost> EmployeePost { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
          
            model.Entity<EmployeePost>()
                .HasOne(x => x.Post)
                .WithMany(x => x.EmployeePosts)
                .HasForeignKey(x => x.IdPost);
            model.Entity<EmployeePost>()
               .HasOne(x => x.Employee)
               .WithMany(x => x.EmployeePosts)
               .HasForeignKey(x => x.IdEmployee);
        }

    }
}
