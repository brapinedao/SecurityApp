using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Identity.Configurations;
using SecurityApp.Identity.Models;

namespace SecurityApp.Identity
{
    public class IdentityTestDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityTestDbContext(DbContextOptions<IdentityTestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
