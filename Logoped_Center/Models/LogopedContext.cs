using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Logoped_Center.Models
{
    public class LogopedContext : IdentityDbContext<User>
    {
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public LogopedContext(DbContextOptions<LogopedContext> options)
            : base(options)
        {
        }

    }
}
