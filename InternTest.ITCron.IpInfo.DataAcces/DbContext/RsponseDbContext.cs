using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternTest.ITCron.IpInfo.DataAcces
{
    public class RsponseDbContext : DbContext
    {
        public RsponseDbContext(DbContextOptions<RsponseDbContext> options) : base(options) { }

        public DbSet<ResponseEntity> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
            
        }
    }

    
}
