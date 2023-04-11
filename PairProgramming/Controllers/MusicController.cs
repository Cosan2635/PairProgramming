using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.Models;
using PairProgramming.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PairProgramming.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    //URL:api/music
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicRepository _repo = new MusicRepository();


        // GET: api/<MusicController>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors]
        [HttpGet]        
        public ActionResult<IEnumerable<Music>> GetAll([FromHeader] int? Amount = null,
                                                       [FromQuery] string? Title = null,
                                                       [FromQuery] int? Duration = null,
                                                       [FromQuery]string? Artist = null)
        {
            // return _repo.GetAll(Title, Duration, Artist);
            List<Music> musics = _repo.GetAll( Amount,Title, Duration, Artist);
            if (musics == null || musics.Count() < 0)
            {
                return NotFound();
            }
           
           Response.Headers.Add("Totalamount", "" + musics.Count);
            return Ok(musics);


        }

        // GET api/<MusicController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType ( StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Music> Get(int id)
        {
           Music? foundmusic = _repo.GetById(id);
            if(foundmusic == null )
            {
                return NotFound();
            }
            return Ok(foundmusic);
        }



        // POST api/<MusicController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Music> Post([FromBody] Music newmusic )
        {
            try
            {
                Music? createdMusic = _repo.AddMusic(newmusic);
                return Created($"api/musics/{createdMusic}", createdMusic);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<MusicController>/5
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Music?> Put(int id, [FromBody] Music updates)
        {
            try
            {
                Music? updateMusic = _repo.updateMusic(id, updates);
                if(updateMusic == null )
                {
                    return NotFound(id);
                }
                return Ok(updateMusic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public ActionResult<Music> Delete(int id)
        {
            Music? deletemusic = _repo.Delete(id);
            if(deletemusic == null )
            {
                return NotFound(id);
            }
            return Ok(deletemusic);
        }
    }
}
