using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityApp.Identity.Models;


namespace SecurityApp.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //Encriptamos con el passwordHasher
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "bfa6789c-ae15-4704-ae59-9f5628f1379c",
                        UserName = "1000365000",
                        PhoneNumber = "573213950000",
                        PhoneNumberConfirmed = true,
                        Email = "brianpineda1908@gmail.com",
                        NormalizedEmail = "brianpineda1908@gmail.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "testPass123*"),
                        NormalizedUserName = "1000365000",
                        Name = "Brian Pineda",
                        UrlPhoto = ""
                    }
            );

        }
    }
}
