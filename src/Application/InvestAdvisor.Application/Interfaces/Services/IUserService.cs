using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task WritePreferenceAsync(GetNotesRequest getNotesRequest);
        public Task<User> CreateUserAsync(CreateUserRequest createUserRequest);
        public Task<User> GetUserAsync(int userId);
        public Task DeleteUserAsync(int userId);
        public Task<string> UserLoginAsync(UserLoginRequest userLoginRequest, string secret);
    }
}