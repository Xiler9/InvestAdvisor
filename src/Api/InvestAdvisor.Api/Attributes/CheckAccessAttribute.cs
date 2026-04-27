using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CheckAccessAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (user?.Identity?.IsAuthenticated != true)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userIdClaim = user.FindFirst("Id");
        if (userIdClaim == null)
        {
            context.Result = new ForbidResult();
            return;
        }

        var userId = int.Parse(userIdClaim.Value);

        var endpoint = context.HttpContext.Request.Path.Value?.ToLower().TrimEnd('/');

        var accessService = context.HttpContext.RequestServices
            .GetRequiredService<IAccessService>();

        var hasAccess = await accessService
            .CheckEndpointAccessAsync(userId, endpoint);

        if (!hasAccess)
        {
            context.Result = new ForbidResult();
        }
    }
}