namespace InvestAdvisor.Application.DTOs
{
    public record UserLoginRequest
    {
        public string? Login { get; init; }
        public string? Password { get; init; }
    }
}