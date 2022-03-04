
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Identity.Models;

namespace Plateform_RH_Finlogik.Identity
{
    public class PlateformRHFinlogikIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlateformRHFinlogikIdentityDbContext(DbContextOptions<PlateformRHFinlogikIdentityDbContext> options) : base(options)
        {
        }
    }
}
