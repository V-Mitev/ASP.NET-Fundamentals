namespace DemoAPI.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            
        }
    }
}
