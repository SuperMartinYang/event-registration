using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Repositories {
    public class EventRepository {
        private readonly ERDbContext _context;
        public EventRepository(ERDbContext context){
            _context = context;
        }
        public async Task<Event> Add(Event ev){
            // use db function to add event
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
            return ev;
        }

        public IEnumerable<Event> GetAll(){
            return _context.Events;
        }
        public async Task<Event> Find(int id){
            return await _context.Events.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<Event> Remove(int id){
            var ev = await _context.Events.SingleAsync(x => x.id == id);
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return ev;
        }
        public async Task<Event> Update(Event ev){
            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
            return ev;
        }
        public async Task<bool> Exists(int id){
            return await _context.Events.AnyAsync(x => x.id == id);
        }
    }
}