using System.Linq;
using System.Net;
using System.Threading.Tasks;
using event_registration.Contracts;
using event_registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_registration.Controllers {
    public class FormAPIController {
        // get repository
        private readonly IFormRepository _repo;
        public FormAPIController(IFormRepository repo){
            _repo = repo;
        }
        // CRUD APIs
        public async Task<bool> FormExists(int id){
            return await _repo.Exists(id);
        }

        [HttpGet("[action]")]
        [Produces(typeof(DbSet<Form>))]
        public IActionResult GetAll(){
            var result = new ObjectResult(_repo.GetAll()){
                StatusCode = (int)HttpStatusCode.OK
            };
            // add total counts to header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _repo.GetAll().Count().ToString());
            return result;
        }

        [HttpGet("id")]
        [Produces(typeof(Form))]
        public async Task<IActionResult> GetForm([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            var form = await _repo.Find(id);
            if (!form) return NotFound(id);
            return Ok(form); 
        }

        [HttpPut("id")]
        [Produces(typeof(Form))]
        public async Task<IActionResult> PutForm([FromBody] Form form, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != form.id) return BadRequest();
            try {
                await _repo.Update(form);
                return Ok(form);
            } catch(DbUpdateConcurrencyException) {
                if (!await FormExists(id))
                    return NotFound()
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(Form))]
        public async Task<IActionResult> PostForm([FromBody] Form form){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                _repo.Add(form);
                return Ok(form);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(Form))]
        public async Task<IActionResult> DeleteForm([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await FormExists(id)) return BadRequest();
            var form = _repo.Remove(id);
            return Ok(form);
        }
    }
}