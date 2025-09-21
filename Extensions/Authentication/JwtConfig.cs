namespace Extensions.Authentication
{
    /// <summary>
    /// Jwt
    /// </summary>
    public class JwtConfig
    {
        public AccessToken AccessToken { get; set; } = new AccessToken();
        public RefreshToken RefreshToken { get; set; } = new RefreshToken();
    }

    public class AccessToken
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }

    public class RefreshToken
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
