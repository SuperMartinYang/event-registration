using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace history_registration.Repositories {
    public class HistoryRepository {
        private readonly ERDbContext _context;
        public HistoryRepository(ERDbContext context){
            _context = context;
        }
        public async Task<History> Add(History history){
            // use db function to add history
            await _context.Histories.AddAsync(history);
            await _context.SaveChangesAsync();
            return history;
        }

        public IEnumerable<History> GetAll(){
            return _context.Histories;
        }
        public async Task<History> Find(int id){
            return await _context.Histories.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<History> Remove(int id){
            var history = await _context.Histories.SingleAsync(x => x.id == id);
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return history;
        }
        public async Task<History> Update(History history){
            _context.Histories.Update(history);
            await _context.SaveChangesAsync();
            return history;
        }
        public async Task<bool> Exists(int id){
            return await _context.Histories.AnyAsync(x => x.id == id);
        }
    }
}