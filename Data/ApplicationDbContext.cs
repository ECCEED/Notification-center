using Microsoft.EntityFrameworkCore;
using NotificationCenterTemplateAPI.Models;

namespace NotificationCenterTemplateAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Template> Templates { get; set; }
    }
}
