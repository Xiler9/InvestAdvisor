using InvestAdvisor.Domain.Enumerators;

namespace InvestAdvisor.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<NoteCategory> Preferences { get; set; } = new List<NoteCategory>();
        public List<AnonymousSurvey> anonymousSurveys { get; set; } = new List<AnonymousSurvey>();
    }
}