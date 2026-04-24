namespace InvestAdvisor.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NoteId { get; set; }
        public string? Description { get; set; }
    }
}