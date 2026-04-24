using AutoMapper;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvestAdvisor.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task WritePreferenceAsync(GetNotesRequest getNotesRequest)
        {
            await _userRepository.WritePreferenceAsync(getNotesRequest);
        }

        public async Task<User> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<User>(createUserRequest);

            _logger.LogInformation("Маппер для создания пользователя успешно скопирован");

            user = await _userRepository.CreateUserAsync(user);

            return user;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            User user = await _userRepository.GetUserAsync(userId);

            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<string> UserLoginAsync(UserLoginRequest userLoginRequest, string secret)
        {
            var user = await _userRepository.GetUserAsync(userLoginRequest);

            return GenerateToken(user, secret);
        }

        private string GenerateToken(User user, string secret)
        {
            var key = Encoding.UTF8.GetBytes(secret);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor();

            tokenDescriptor.Expires = DateTime.UtcNow.AddDays(1);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            tokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>() { new Claim("userId", user.Id.ToString()) });

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}