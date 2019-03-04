using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// my namespaces
using Microsoft.EntityFrameworkCore;
using System.Net;
using event_registration.Contracts;
using event_registration.Models;

namespace event_registration.Controllers {
    [Route("api/[controller]")]
    public class EmailAPIController {
        // get repository
        private readonly IEmailRepository _repo;
        public EmailAPIController(IEmailRepository repo){
            _repo = repo;
        }
        // CRUD APIs
        public async Task<bool> EmailExists(int id){
            return await _repo.Exists(id);
        }

        [HttpGet("[action]")]
        [Produces(typeof(DbSet<Email>))]
        public IActionResult GetAll(){
            var result = new ObjectResult(_repo.GetAll()){
                StatusCode = (int)HttpStatusCode.OK
            };
            // add total counts to header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _repo.GetAll().Count().ToString());
            return result;
        }

        [HttpGet("id")]
        [Produces(typeof(Email))]
        public async Task<IActionResult> GetEmail([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            var email = await _repo.Find(id);
            if (!email) return NotFound(id);
            return Ok(email); 
        }

        [HttpPut("id")]
        [Produces(typeof(Email))]
        public async Task<IActionResult> PutEmail([FromBody] Email email, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != email.id) return BadRequest();
            try {
                await _repo.Update(email);
                return Ok(email);
            } catch(DbUpdateConcurrencyException) {
                if (!await EmailExists(id))
                    return NotFound();
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(Email))]
        public async Task<IActionResult> PostEmail([FromBody] Email email){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                _repo.Add(email);
                return Ok(email);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(Email))]
        public async Task<IActionResult> DeleteEmail([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await EmailExists(id)) return BadRequest();
            var email = _repo.Remove(id);
            return Ok(email);
        }
    }
}