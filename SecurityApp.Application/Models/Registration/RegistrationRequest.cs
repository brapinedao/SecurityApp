namespace SecurityApp.Application.Models.Registration
{
    public class RegistrationRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string UrlPhoto { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;

    }
}
