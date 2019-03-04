namespace event_registration.Controllers {
    public class ParticipantAPIController {
        // get repository
        private readonly IParticipantRepository _repo;
        public ParticipantAPIController(IParticipantRepository repo){
            _repo = repo;
        }
        // CRUD APIs
        public async Task<bool> ParticipantExists(int id){
            return await _repo.Exists(id);
        }

        [HttpGet("[action]")]
        [Produces(typeof(DbSet<Participant>))]
        public IActionResult GetAll(){
            var result = new ObjectResult(_repo.GetAll()){
                StatusCode = (int)HttpStatusCode.OK
            };
            // add total counts to header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _repo.GetAll().Count().ToString());
            return result;
        }

        [HttpGet("id")]
        [Produces(typeof(Participant))]
        public async Task<IActionResult> GetParticipant([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            var participant = await _repo.Find(id);
            if (!participant) return NotFound(id);
            return Ok(participant); 
        }

        [HttpPut("id")]
        [Produces(typeof(Participant))]
        public async Task<IActionResult> PutParticipant([FromBody] Participant participant, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != participant.id) return BadRequest();
            try {
                await _repo.Update(participant);
                return Ok(participant);
            } catch(DbUpdateConcurrencyException) {
                if (!await ParticipantExists(id))
                    return NotFound()
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(Participant))]
        public async Task<IActionResult> PostParticipant([FromBody] Participant participant){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                _repo.Add(participant);
                return Ok(participant);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(Participant))]
        public async Task<IActionResult> DeleteParticipant([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await ParticipantExists(id)) return BadRequest();
            var participant = _repo.Remove(id);
            return Ok(participant);
        }        
    }
}