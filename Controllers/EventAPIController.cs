using System.Linq;
using System.Net;
using System.Threading.Tasks;
using event_registration.Contracts;
using event_registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_registration.Controllers {
    public class EventAPIController {
        // get repository
        private readonly IEventRepository _repo;
        public EventAPIController(IEventRepository repo){
            _repo = repo;
        }
        // CRUD APIs
        public async Task<bool> EventExists(int id){
            return await _repo.Exists(id);
        }

        [HttpGet("[action]")]
        [Produces(typeof(DbSet<Event>))]
        public IActionResult GetAll(){
            var result = new ObjectResult(_repo.GetAll()){
                StatusCode = (int)HttpStatusCode.OK
            };
            // add total counts to header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _repo.GetAll().Count().ToString());
            return result;
        }

        [HttpGet("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> GetEvent([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            var ev = await _repo.Find(id);
            if (!ev) return NotFound(id);
            return Ok(ev); 
        }

        [HttpPut("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> PutEvent([FromBody] Event ev, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != ev.id) return BadRequest();
            try {
                await _repo.Update(ev);
                return Ok(ev);
            } catch(DbUpdateConcurrencyException) {
                if (!await EventExists(id))
                    return NotFound()
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> PostEvent([FromBody] Event ev){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                await _repo.Add(ev);
                return Ok(ev);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await EventExists(id)) return BadRequest();
            var ev = _repo.Remove(id);
            return Ok(ev);
        }
    }
}