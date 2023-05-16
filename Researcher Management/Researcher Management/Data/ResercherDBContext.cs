using Microsoft.EntityFrameworkCore;

namespace Researcher_Management.Data
{
    public class ResercherDBContext : DbContext
    {
        public ResercherDBContext(DbContextOptions<ResercherDBContext> options) : base(options)
        {

        }

        public DbSet<CanBoNghienCuu> canBoNghienCuu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}
