namespace InvestAdvisor.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; init; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Сomment> Comments { get; set; } = new List<Сomment>();
    }
}