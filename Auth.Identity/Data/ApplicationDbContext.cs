using Auth.Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Identity.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> Users { get; set; }
        
    }
}
