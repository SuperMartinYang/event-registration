namespace history_registration.Repositories {
    public class HistoryRepository {
        private readonly ERDbContext _context;
        public HistoryRepository(ERDbContext context){
            _context = context;
        }
        public async Task<History> Add(History history){
            // use db function to add history
            await _context.Historys.AddAsync(history);
            await _context.SaveChangesAsync();
            return history;
        }

        public IEumerable<History> GetAll(){
            return _context.Historys;
        }
        public async Task<History> Find(int id){
            return await _context.Historys.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<History> Remove(int id){
            var history = await _context.Historys.SingleAsync(x => x.id == id);
            _context.Historys.Remove(history);
            await _context.SaveChangesAsync();
            return history;
        }
        public async Task<History> Update(History history){
            _context.Historys.Update(history);
            await _context.SaveChangesAsync();
            return history;
        }
        public async Task<bool> Exists(int id){
            return await _context.Historys.AnyAsync(x => x.id == id);
        }
    }
}