using Microsoft.AspNetCore.Identity;
using System;

namespace Auth.Identity.Data.Entities
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
