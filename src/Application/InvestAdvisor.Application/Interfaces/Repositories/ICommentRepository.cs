using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Task<Comment> GetCommentAsync(int commentId);
        public Task<Comment> CreateCommentAsync(Comment comment);
        public Task DeleteCommentAsync(int commentId);
    }
}