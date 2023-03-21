using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.Models;
using PairProgramming.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PairProgramming.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    //URI:api/music
    [ApiController]
    public class MusicController : ControllerBase
    {
        private MusicRepository _repo;

        public MusicController(MusicRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<MusicController>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors]
        [HttpGet]        
        public ActionResult<IEnumerable<Music>> GetAll([FromQuery] string? title,
                                                       [FromQuery] int duration,
                                                       [FromQuery]string? artist)
        {
            List<Music>? result = _repo.GetAll(title,duration,artist);
            if(result.Count < 1)
            { 
               return NotFound();
            }
            return Ok(result);

        }

        // GET api/<MusicController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
