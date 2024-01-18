using CounterApi.Data;
using CounterApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace CounterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountersController : ControllerBase
    {
        private List<Counter> Counters = new List<Counter>();

        private readonly ILogger<CountersController> _logger;

        private readonly CounterDbContext _context;

        public CountersController(ILogger<CountersController> logger, CounterDbContext context)
        {
            Counters.Add(new Counter() { Name = "GenericCounter", Number = 1});
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Counter> GetCounters()
        {
            return _context.Counters;
        }

        [HttpPost]
        public ActionResult PostCounter(string name)
        {
            int index = Counters.FindIndex(x => x.Name == name);
            if (index == -1)
            {
                Counter counter = new Counter() { Name = name, Number = 1 };
                Counters.Add(counter);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{name}")]
        public ActionResult PutCounter(string name)
        {
            int index = Counters.FindIndex(c => c.Name == name);
            if(index == -1)
            {
                return NotFound();
            }
            Counters[index].Number++;
            return Ok();
        }

        [HttpDelete("{name}")]
        public ActionResult DeleteCounter(string name)
        {
            int index = Counters.FindIndex(c => c.Name == name);
            if (index == -1)
            {
                return NotFound();
            }

            Counters[index].Number--;
            if (Counters[index].Number == 0)
            {
                Counters.Remove(Counters[index]);
            }

            return Ok();
        }

        [HttpGet("{name}")]
        public ActionResult<Counter> GetCounter(string name)
        {
            int index = Counters.FindIndex(c => c.Name == name);
            if (index == -1)
            {
                return NotFound();
            }

            return Counters[index];
        }
    }
}
