using AutoMapper;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;

namespace InvestAdvisor.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<CommentService> _logger;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, ILogger<CommentService> logger)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Comment> CreateCommentAsync(CreateCommentRequest createCommentRequest, int userId)
        {
            var comment = _mapper.Map<Comment>(createCommentRequest);

            comment.UserId = userId;

            _logger.LogInformation("Маппер для создания комментария успешно скопирован");

            comment = await _commentRepository.CreateCommentAsync(comment);

            return comment;
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            await _commentRepository.DeleteCommentAsync(commentId);
        }
    }
}