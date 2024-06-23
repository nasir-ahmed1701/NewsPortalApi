namespace NewsPortal.Api.Models
{
    public class CorsConfiguration
    {
        public required string PolicyName { get; set; }
        public required string[] AllowedOrigins { get; set; }
    }
}
