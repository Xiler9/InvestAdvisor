using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface ICommentService
    {
        public Task<Comment> CreateCommentAsync(CreateCommentRequest createCommentRequest, int userId);
        public Task DeleteCommentAsync(int commentId);
    }
}