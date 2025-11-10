namespace InvestAdvisor.Api.DTOs.Requests
{
    public record CreatePostRequest
    {
        public int UserId { get; init; }
        public string Title { get; init; }
        public string Text { get; init; }
    }
}