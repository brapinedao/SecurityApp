using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SecurityApp.Identity.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                   new IdentityUserRole<string>
                   {
                       RoleId = "934b6a0a-69b0-4833-ac1d-ac17dfecd1d8",
                       UserId = "bfa6789c-ae15-4704-ae59-9f5628f1379c"
                   }
                   );
        }
    }
}
