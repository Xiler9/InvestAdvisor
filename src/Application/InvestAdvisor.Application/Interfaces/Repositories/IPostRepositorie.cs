using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface IPostRepositorie
    {
        public Task CreatePostAsync(Post post);
        public Task<List<Post>> GetAllPostsAsync();
    }
}