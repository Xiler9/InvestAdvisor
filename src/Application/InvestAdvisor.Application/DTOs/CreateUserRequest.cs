namespace InvestAdvisor.Application.DTOs
{
    public record CreateUserRequest
    {
        public string? NickName { get; init; }
        public string? Email { get; init; }
    }
}