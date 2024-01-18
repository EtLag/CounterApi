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

        public CountersController(ILogger<CountersController> logger)
        {
            Counters.Add(new Counter() { Name = "GenericCounter", Number = 1});
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Counter> GetCounters()
        {
            return Counters;
        }

        [HttpPost]
        public ActionResult PostCounter(string name)
        {
            Counter counter = new Counter() { Name = name, Number = 1 };
            Counters.Add(counter);
            return Ok();
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
    }
}
