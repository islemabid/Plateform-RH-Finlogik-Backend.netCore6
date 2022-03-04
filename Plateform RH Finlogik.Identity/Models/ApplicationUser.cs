using Microsoft.AspNetCore.Identity;

namespace Plateform_RH_Finlogik.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
