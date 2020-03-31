using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using peopleAPI.Services;
using peopleAPI.Models;

namespace peopleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _PeopleService;

        public PeopleController(PeopleService PeopleService)
        {
            _PeopleService = PeopleService;
        }

        [HttpGet]
        public ActionResult<List<People>> Get() =>
            _PeopleService.Get();

        [HttpGet("{id:length(24)}", Name = "Getpeople")]
        public ActionResult<People> Get(string id)
        {
            var people = _PeopleService.Get(id);

            if (people == null)
            {
                return NotFound();
            }

            return people;
        }

        [HttpPost]
        public ActionResult<People> Create(People people)
        {
            _PeopleService.Create(people);

            return CreatedAtRoute("Getpeople", new { id = people.Id.ToString() }, people);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, People peopleIn)
        {
            var people = _PeopleService.Get(id);

            if (people == null)
            {
                return NotFound();
            }

            _PeopleService.Update(id, peopleIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var People = _PeopleService.Get(id);

            if (People == null)
            {
                return NotFound();
            }

            _PeopleService.Remove(People.Id);

            return NoContent();
        }
    }
}