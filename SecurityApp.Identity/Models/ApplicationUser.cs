using Microsoft.AspNetCore.Identity;

namespace SecurityApp.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; } = String.Empty;

        public string UrlPhoto { get; set; } = String.Empty;
    }
}
