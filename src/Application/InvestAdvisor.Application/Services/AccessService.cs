using InvestAdvisor.Application.Interfaces.Repositories;

public class AccessService : IAccessService
{
    private readonly IAccessRepository _repository;

    public AccessService(IAccessRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> CheckEndpointAccessAsync(int userId, string endpoint)
    {
        return _repository.HasEndpointAccessAsync(userId, endpoint);
    }
}