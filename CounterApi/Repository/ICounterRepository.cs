using CounterApi.Models;

namespace CounterApi.Repository
{
    public interface ICounterRepository
    {
        void Insert(Counter counter);
        List<Counter> GetAllCounters();
        void Delete(Counter counter);
        void Update(Counter counter);
        Counter? GetCounter(string name);
    }
}
