using AutoMapper;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>();
        }
    }
}