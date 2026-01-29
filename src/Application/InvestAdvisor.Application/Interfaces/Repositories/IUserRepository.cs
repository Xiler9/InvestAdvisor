using InvestAdvisor.Application.DTOs;

namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task WritePreferenceAsync(GetNotesRequest getNotesRequest);
    }
}