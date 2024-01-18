using CounterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterApi.Data
{
    public class CounterDbContext : DbContext
    {
        public CounterDbContext(DbContextOptions<CounterDbContext> options) : base(options)
        {

        }

        public DbSet<Counter> Counters { get; set; }
    }
}
