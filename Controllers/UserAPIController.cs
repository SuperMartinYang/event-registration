namespace event_registration.Controllers {
    public class UserAPIController {
        // get repository
        private readonly IUserRepository _repo;
        public UserAPIController(IUserRepository repo){
            _repo = repo;
        }
        // CRUD APIs
        public async Task<bool> UserExists(int id){
            return await _repo.Exists(id);
        }

        [HttpGet("[action]")]
        [Produces(typeof(DbSet<User>))]
        public IActionResult GetAll(){
            var result = new ObjectResult(_repo.GetAll()){
                StatusCode = (int)HttpStatusCode.OK
            };
            // add total counts to header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _repo.GetAll().Count().ToString());
            return result;
        }

        [HttpGet("id")]
        [Produces(typeof(User))]
        public async Task<IActionResult> GetUser([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            var user = await _repo.Find(id);
            if (!user) return NotFound(id);
            return Ok(user); 
        }

        [HttpPut("id")]
        [Produces(typeof(User))]
        public async Task<IActionResult> PutUser([FromBody] User user, [FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (id != user.id) return BadRequest();
            try {
                await _repo.Update(user);
                return Ok(user);
            } catch(DbUpdateConcurrencyException) {
                if (!await UserExists(id))
                    return NotFound()
                else throw;
            }
        }

        [HttpPost("id")]
        [Produces(typeof(User))]
        public async Task<IActionResult> PostUser([FromBody] User user){
            if (!ModelState.isValid) return BadRequest(ModelState);
            try {
                _repo.Add(user);
                return Ok(user);
            } catch (DbUpdateConcurrencyException){
                throw;
            }
        }

        [HttpDelete("id")]
        [Produces(typeof(User))]
        public async Task<IActionResult> DeleteUser([FromRoute] int id){
            if (!ModelState.isValid) return BadRequest(ModelState);
            if (!await UserExists(id)) return BadRequest();
            var user = _repo.Remove(id);
            return Ok(user);
        }        
    }
}