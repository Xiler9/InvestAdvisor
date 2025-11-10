using AutoMapper;
using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;

namespace InvestAdvisor.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepositorie _userRepositorie;

        private readonly IMapper _mapper;

        private readonly ILogger<PostService> _logger;

        public PostService(IPostRepositorie userRepositorie, IMapper mapper, ILogger<PostService> logger)
        {
            _userRepositorie = userRepositorie;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreatePostAsync(CreatePostRequest createPostRequest)
        {
            var post = _mapper.Map<Post>(createPostRequest);

            _logger.LogInformation("Маппер успешно скопирован");

            await _userRepositorie.CreatePostAsync(post);
        }
    }
}