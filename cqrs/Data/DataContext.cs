using cqrs.Entities;
using Microsoft.EntityFrameworkCore;

namespace cqrs.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
