namespace SecurityApp.Application.Models.Auth
{
    public class AuthResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string UrlPhoto { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public bool Status { get; set; } = false;
        public string Message { get; set; } = String.Empty;


    }
}
