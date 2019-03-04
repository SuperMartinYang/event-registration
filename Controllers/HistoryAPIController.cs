using System.Linq;
using System.Net;
using System.Threading.Tasks;
using event_registration.Contracts;
using event_registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_registration.Controllers {
    public class HistoryAPIController {
        // get repository
        private readonly IHistoryRepository _repo;
        public HistoryAPIController(IHistoryRepository repo){
            _repo = repo;
        }
        // CRUD APIs
        public async Task<bool> HistoryExists(int id){
            return await _repo.Exists(id);
        }

        [HttpGet("[action]")]
        [Produces(typeof(DbSet<History>))]
        public IActionResult GetAll(){
            var result = new ObjectResult(_repo.GetAll()){
                StatusCode = (int)HttpStatusCode.OK
            };
            // add total counts to header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _repo.GetAll().Count().ToString());
            return result;
        }

        [HttpGet("id")]
        [Produces(typeof(History))]
        public async Task<IActionResult> GetHistory([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            var history = await _repo.Find(id);
            if (!history) return NotFound(id);
            return Ok(history); 
        }

        [HttpPut("id")]
        [Produces(typeof(History))]
        public async Task<IActionResult> PutHistory([FromBody] History history, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != history.id) return BadRequest();
            try {
                await _repo.Update(history);
                return Ok(history);
            } catch(DbUpdateConcurrencyException) {
                if (!await HistoryExists(id))
                    return NotFound()
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(History))]
        public async Task<IActionResult> PostHistory([FromBody] History history){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                _repo.Add(history);
                return Ok(history);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(History))]
        public async Task<IActionResult> DeleteHistory([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await HistoryExists(id)) return BadRequest();
            var history = _repo.Remove(id);
            return Ok(history);
        }        
    }
}