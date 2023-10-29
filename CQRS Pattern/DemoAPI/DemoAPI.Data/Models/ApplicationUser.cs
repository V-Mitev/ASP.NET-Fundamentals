namespace DemoAPI.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            
        }
    }
}
