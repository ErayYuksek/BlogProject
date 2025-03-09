using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server =ERAY\\SQLEXPRESS; database=BlogLiveApiDb; integrated security=true;TrustServerCertificate=True");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
