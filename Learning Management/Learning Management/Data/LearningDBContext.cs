using Microsoft.EntityFrameworkCore;
using Learning_Management.Data;

namespace Learning_Management.Data
{
    public class LearningDBContext : DbContext
    {
        public LearningDBContext(DbContextOptions<LearningDBContext> options) : base(options)
        {

        }
        public DbSet<NhanSu> NhanSu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

    }
}
