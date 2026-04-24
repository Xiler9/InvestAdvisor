namespace InvestAdvisor.Application.DTOs
{
    public record CreateCommentRequest
    {
        public int NoteId { get; set; }
        public string? Description { get; set; }
    }
}