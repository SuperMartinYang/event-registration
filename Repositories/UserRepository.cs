namespace user_registration.Repositories {
    public class UserRepository {
        private readonly ERDbContext _context;
        public UserRepository(ERDbContext context){
            _context = context;
        }
        public async Task<User> Add(User user){
            // use db function to add user
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public IEumerable<User> GetAll(){
            return _context.Users;
        }
        public async Task<User> Find(int id){
            return await _context.Users.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<User> Remove(int id){
            var user = await _context.Users.SingleAsync(x => x.id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(User user){
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> Exists(int id){
            return await _context.Users.AnyAsync(x => x.id == id);
        }
    }
}