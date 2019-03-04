using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace participant_registration.Repositories {
    public class ParticipantRepository {
        private readonly ERDbContext _context;
        public ParticipantRepository(ERDbContext context){
            _context = context;
        }
        public async Task<Participant> Add(Participant participant){
            // use db function to add participant
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
            return participant;
        }

        public IEnumerable<Participant> GetAll(){
            return _context.Participants;
        }
        public async Task<Participant> Find(int id){
            return await _context.Participants.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<Participant> Remove(int id){
            var participant = await _context.Participants.SingleAsync(x => x.id == id);
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
            return participant;
        }
        public async Task<Participant> Update(Participant participant){
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();
            return participant;
        }
        public async Task<bool> Exists(int id){
            return await _context.Participants.AnyAsync(x => x.id == id);
        }
    }
}