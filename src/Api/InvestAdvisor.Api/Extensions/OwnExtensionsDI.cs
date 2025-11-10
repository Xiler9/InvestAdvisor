using FluentValidation;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Application.Services;
using InvestAdvisor.Infrastructure;
using InvestAdvisor.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InvestAdvisor.Api.Extensions
{
    public static class OwnExtensionsDI
    {
        public static IServiceCollection AddOwnExtensions(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //Add DI to services

            services.AddScoped<IPostService, PostService>();

            //Add DI to repositories

            services.AddScoped<IPostRepositorie, PostRepositorie>();

            //Add DI to validators

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            //Add DI to mappers

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Add DI to Db

            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}