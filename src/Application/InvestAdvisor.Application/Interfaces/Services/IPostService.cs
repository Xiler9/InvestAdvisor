using InvestAdvisor.Api.DTOs.Requests;

namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface IPostService
    {
        public Task CreatePostAsync(CreatePostRequest createPostRequest);
    }
}