using InvestAdvisor.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestAdvisor.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AnonymousSurvey> AnonymousSurveys { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleEndpoint> RoleEndpoints { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
    }
}