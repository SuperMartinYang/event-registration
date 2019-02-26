namespace event_registration.Repositories {
    public class EventRepository {
        private readonly ERDbContext _context;
        public EventRepository(ERDbContext context){
            _context = context;
        }
        public async Task<Event> Add(Event event){
            // use db function to add event
            await _context.Events.AddAsync(event);
            await _context.SaveChangesAsync();
            return event;
        }

        public IEumerable<Event> GetAll(){
            return _context.Events;
        }
        public async Task<Event> Find(int id){
            return await _context.Events.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<Event> Remove(int id){
            var event = await _context.Events.SingleAsync(x => x.id == id);
            _context.Events.Remove(event);
            await _context.SaveChangesAsync();
            return event;
        }
        public async Task<Event> Update(Event event){
            _context.Events.Update(event);
            await _context.SaveChangesAsync();
            return event;
        }
        public async Task<bool> Exists(int id){
            return await _context.Events.AnyAsync(x => x.id == id);
        }
    }
}