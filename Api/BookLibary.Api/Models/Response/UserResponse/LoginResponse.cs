namespace BookLibary.Api.Models.Response.UserResponse
{
    public class LoginResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }

    }
}
