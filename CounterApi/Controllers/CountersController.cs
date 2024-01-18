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
            _logger = logger;
        }

        [HttpGet(Name = "GetCounters")]
        public IEnumerable<Counter> Get()
        {
            return Counters;
        }

        [HttpPost(Name = "PostCounter")]
        public void Post(Counter counter)
        {
            Counters.Add(counter);
        }
    }
}
