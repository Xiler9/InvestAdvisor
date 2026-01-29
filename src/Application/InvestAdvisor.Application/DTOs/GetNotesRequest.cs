using InvestAdvisor.Domain.Enumerators;

namespace InvestAdvisor.Application.DTOs
{
    public record GetNotesRequest
    {
        public NoteCategory Category { get; init; }
        public int UserId { get; init; }
    }
}