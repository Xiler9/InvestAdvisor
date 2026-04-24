using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InvestAdvisor.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task WritePreferenceAsync(GetNotesRequest getNotesRequest)
        {
            var user = await _appDbContext.Users.FindAsync(getNotesRequest.UserId);

            user.Preferences.Add(getNotesRequest.Category);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);

            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId);

            return user;
        }

        public async Task<User> GetUserAsync(UserLoginRequest userLoginRequest)
        {
            var user = await _appDbContext.Users.FirstAsync(x => x.Login == userLoginRequest.Login && x.Password == userLoginRequest.Password);

            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserAsync(userId);

            _appDbContext.Users.Remove(user);

            await _appDbContext.SaveChangesAsync();
        }
    }
}