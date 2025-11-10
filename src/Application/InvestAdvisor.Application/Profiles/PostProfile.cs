using AutoMapper;
using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<CreatePostRequest, Post>();
        }
    }
}