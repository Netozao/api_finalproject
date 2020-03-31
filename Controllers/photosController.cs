using photosAPI.Models;
using photosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace photosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class photosController : ControllerBase
    {
        private readonly PhotosService _photoservice;

        public photosController(PhotosService photoservice)
        {
            _photoservice = photoservice;
        }

        [HttpGet]
        public ActionResult<List<photos>> Get() =>
            _photoservice.Get();

        [HttpGet("{id:length(24)}", Name = "Getphoto")]
        public ActionResult<photos> Get(string id)
        {
            var photo = _photoservice.Get(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        [HttpPost]
        public ActionResult<photos> Create(photos photo)
        {
            _photoservice.Create(photo);

            return CreatedAtRoute("Getphoto", new { id = photo.Id.ToString() }, photo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, photos photoIn)
        {
            var photo = _photoservice.Get(id);

            if (photo == null)
            {
                return NotFound();
            }

            _photoservice.Update(id, photoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var photo = _photoservice.Get(id);

            if (photo == null)
            {
                return NotFound();
            }

            _photoservice.Remove(photo.Id);

            return NoContent();
        }
    }
}