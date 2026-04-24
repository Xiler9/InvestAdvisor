using InvestAdvisor.Domain.Enumerators;

namespace InvestAdvisor.Api.DTOs.Requests
{
    public record CreateNoteRequest
    {
        public string? Title { get; init; }
        public string? Text { get; init; }
        public NoteCategory Category { get; init; }
    }
}