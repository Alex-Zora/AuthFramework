namespace ShanYue.Model.ConfigModel
{
    public class JwtConfig
    {
        public required string SecretKey { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
