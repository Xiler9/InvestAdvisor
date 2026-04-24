using InvestAdvisor.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InvestAdvisor.Api.Middlewares
{
    public class JwtAthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly string _secret;

        public JwtAthenticationMiddleware(RequestDelegate next, IOptions<AuthSettings> options)
        {
            _next = next;
            _secret = options.Value.Secret;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                await _next.Invoke(context);
            }
            else
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };

                    var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;

                    var userId = int.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "userId")?.Value ?? string.Empty);

                    context.Items["userId"] = userId;

                    await _next(context);

                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 401;

                    await context.Response.WriteAsync($"Ошибка аутентификации: {ex.Message}");

                    return;
                }
            }       
        }
    }
}