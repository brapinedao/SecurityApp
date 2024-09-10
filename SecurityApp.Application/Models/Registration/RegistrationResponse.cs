namespace SecurityApp.Application.Models.Registration
{
    public class RegistrationResponse
    {
        public string Id { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string UrlPhoto { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public bool Status { get; set; } = false;
        public string Message { get; set; } = String.Empty;


    }
}
