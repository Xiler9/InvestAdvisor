using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;

namespace InvestAdvisor.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<CommentRepository> _logger;

        public CommentRepository(AppDbContext appDbContext, ILogger<CommentRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Comment> GetCommentAsync(int commentId)
        {
            var comment = await _appDbContext.Comments.FindAsync(commentId);

            return comment;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            await _appDbContext.Comments.AddAsync(comment);

            await _appDbContext.SaveChangesAsync();

            return comment;
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await GetCommentAsync(commentId);

            _appDbContext.Comments.Remove(comment);

            await _appDbContext.SaveChangesAsync();
        }
    }
}