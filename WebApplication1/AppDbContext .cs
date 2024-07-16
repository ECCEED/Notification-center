using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using WebApplication1.Entities;

namespace WebApplication1
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {


        }

        // Define your DbSets (tables)
        public DbSet<Template> Templates { get; set; } 
    }

}
