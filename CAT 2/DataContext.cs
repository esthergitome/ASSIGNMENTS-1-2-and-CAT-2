using Microsoft.EntityFrameworkCore;

namespace KCAResultSlip
{
    public class DataContext : DbContext
    {
        public DbSet<ResultRecord> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=KCAResults.db");
        }

        public DataContext()
        {
            Database.EnsureCreated();
        }
    }
}
