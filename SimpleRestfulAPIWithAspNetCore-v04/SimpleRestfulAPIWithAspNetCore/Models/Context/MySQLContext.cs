using Microsoft.EntityFrameworkCore;

namespace SimpleRestfulAPIWithAspNetCore.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Books { get; set; }
    }
}
