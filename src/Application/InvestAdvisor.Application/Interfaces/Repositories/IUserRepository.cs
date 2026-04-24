using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task WritePreferenceAsync(GetNotesRequest getNotesRequest);
        public Task<User> CreateUserAsync(User user);
        public Task<User> GetUserAsync(int userId);
        public Task<User> GetUserAsync(UserLoginRequest userLoginRequest);
        public Task DeleteUserAsync(int  userId);
    }
}