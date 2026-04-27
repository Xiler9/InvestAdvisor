using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Domain.Models;
using Konscious.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

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
            user.Password = GenerateHashPassword(user.Password);

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
            var user = await _appDbContext.Users.FirstAsync(x => x.Login == userLoginRequest.Login && x.Password == GenerateHashPassword(userLoginRequest.Password));

            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserAsync(userId);

            _appDbContext.Users.Remove(user);

            await _appDbContext.SaveChangesAsync();
        }

        private string GenerateHashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                MemorySize = 65536,
                Iterations = 3
            };
            var hash = argon2.GetBytes(32);
            string hashString = Convert.ToBase64String(hash);

            return hashString;
        }
    }
}