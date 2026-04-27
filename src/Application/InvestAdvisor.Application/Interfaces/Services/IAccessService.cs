namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface IAccessService
    {
        Task<bool> CheckEndpointAccessAsync(int userId, string endpoint);
    }
}