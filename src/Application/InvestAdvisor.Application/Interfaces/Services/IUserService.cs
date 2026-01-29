using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task WritePreferenceAsync(GetNotesRequest getNotesRequest);
        public Task<User> CreateUserAsync(CreateUserRequest createUserRequest);
    }
}