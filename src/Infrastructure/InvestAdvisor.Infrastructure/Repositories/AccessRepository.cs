using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class AccessRepository : IAccessRepository
{
    private readonly AppDbContext _appDbContext;

    public AccessRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> HasEndpointAccessAsync(int userId, string endpoint)
    {
        return await _appDbContext.UserRoles
        .Where(ur => ur.UserId == userId)
        .SelectMany(ur => _appDbContext.RoleEndpoints
            .Where(re => re.RoleId == ur.RoleId))
        .SelectMany(re => _appDbContext.Endpoints
            .Where(e => e.Id == re.EndpointId))
        .AnyAsync(e => e.Path == endpoint);
    }
}