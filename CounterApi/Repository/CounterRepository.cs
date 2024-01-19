using CounterApi.Data;
using CounterApi.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CounterApi.Repository
{
    public class CounterRepository : ICounterRepository
    {
        private CounterDbContext _context;
        private DbSet<Counter> _dbSet;

        public CounterRepository(CounterDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<Counter>();
        }

        public virtual void Insert(Counter counter)
        {
            _dbSet.Add(counter);
            _context.SaveChanges();
        }

        public virtual void Update(Counter counter)
        {
            _dbSet.Update(counter);
            _context.SaveChanges();
        }

        public virtual void Delete(Counter counter) 
        {
            _dbSet.Remove(counter);
            _context.SaveChanges();
        }

        public virtual List<Counter> GetAllCounters() 
        {
            return _context.Counters.ToList();
        }

        public virtual Counter? GetCounter(string name)
        {
            Counter? counter = _context.Counters.ToList().Find(c => c.Name == name);
            return counter;
        }
    }
}
