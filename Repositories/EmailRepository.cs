namespace event_registration.Repositories {
    public class EmailRepository {
        private readonly ERDbContext _context;
        public EmailRepository(ERDbContext context){
            _context = context;
        }
        public async Task<Email> Add(Email email){
            // use db function to add email
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
            return email;
        }

        public IEumerable<Email> GetAll(){
            return _context.Emails;
        }
        public async Task<Email> Find(int id){
            return await _context.Emails.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<Email> Remove(int id){
            var email = await _context.Emails.SingleAsync(x => x.id == id);
            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            return email;
        }
        public async Task<Email> Update(Email email){
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();
            return email;
        }
        public async Task<bool> Exists(int id){
            return await _context.Emails.AnyAsync(x => x.id == id);
        }
    }
}