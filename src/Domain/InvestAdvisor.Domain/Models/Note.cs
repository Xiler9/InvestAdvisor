namespace InvestAdvisor.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; init; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}