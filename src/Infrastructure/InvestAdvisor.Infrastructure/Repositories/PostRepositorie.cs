using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestAdvisor.Infrastructure.Repositories
{
    public class PostRepositorie : IPostRepositorie
    {
        private readonly AppDbContext _appDbContext;

        public PostRepositorie(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreatePostAsync(Post post)
        {
            await _appDbContext.Posts.AddAsync(post);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            var posts = await _appDbContext.Posts.ToListAsync();

            return posts;
        }
    }
}