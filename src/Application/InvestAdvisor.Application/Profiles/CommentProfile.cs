using AutoMapper;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentRequest, Comment>();
        }
    }
}
