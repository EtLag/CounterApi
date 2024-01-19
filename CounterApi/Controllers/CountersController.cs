using CounterApi.Data;
using CounterApi.Models;
using CounterApi.Repository;
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

        private readonly CounterRepository _repository;

        public CountersController(ILogger<CountersController> logger, CounterDbContext context)
        {
            Counters.Add(new Counter() { Name = "GenericCounter", Number = 1});
            _logger = logger;
            _repository = new CounterRepository(context);
        }

        [HttpGet]
        public IEnumerable<Counter> GetCounters()
        {
            return _repository.GetAllCounters();
        }

        [HttpPost]
        public ActionResult PostCounter(string name)
        {
            Counter? counter = _repository.GetCounter(name);
            if (counter == null)
            {
                counter = new Counter() { Name = name, Number = 1 };
                _repository.Insert(counter);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{name}")]
        public ActionResult PutCounter(string name)
        {
            Counter? counter = _repository.GetCounter(name);
            if (counter == null)
            {
                return NotFound();
            }
            counter.Number++;
            _repository.Update(counter);
            return Ok();
        }

        [HttpDelete("{name}")]
        public ActionResult DeleteCounter(string name)
        {
            Counter? counter = _repository.GetCounter(name);
            if (counter == null)
            {
                return NotFound();
            }

            counter.Number--;
            if (counter.Number == 0)
            {
                _repository.Delete(counter);
            }
            else
            {
                _repository.Update(counter);
            }

            return Ok();
        }

        [HttpGet("{name}")]
        public ActionResult<Counter> GetCounter(string name)
        {
            Counter? counter = _repository.GetCounter(name);
            if (counter == null)
            {
                return NotFound();
            }

            return counter;
        }
    }
}
