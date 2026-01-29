namespace InvestAdvisor.Domain.Models
{
    public class AnonymousSurvey
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, ushort> Options { get; set; } = new Dictionary<string, ushort>();
    }
}