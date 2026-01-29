using AutoMapper;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;

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
    }
}