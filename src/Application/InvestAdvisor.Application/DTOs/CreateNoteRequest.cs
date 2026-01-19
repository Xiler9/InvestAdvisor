namespace InvestAdvisor.Api.DTOs.Requests
{
    public record CreateNoteRequest
    {
        public int UserId { get; init; }
        public string? Title { get; init; }
        public string? Text { get; init; }
    }
}