namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface IAccessRepository
    {
        Task<bool> HasEndpointAccessAsync(int userId, string endpoint);
    }
}