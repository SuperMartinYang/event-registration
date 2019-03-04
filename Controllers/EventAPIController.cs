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
            var event = await _repo.Find(id);
            if (!event) return NotFound(id);
            return Ok(event); 
        }

        [HttpPut("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> PutEvent([FromBody] Event event, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != event.id) return BadRequest();
            try {
                await _repo.Update(event);
                return Ok(event);
            } catch(DbUpdateConcurrencyException) {
                if (!await EventExists(id))
                    return NotFound()
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> PostEvent([FromBody] Event event){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                _repo.Add(event);
                return Ok(event);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(Event))]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await EventExists(id)) return BadRequest();
            var event = _repo.Remove(id);
            return Ok(event);
        }
    }
}