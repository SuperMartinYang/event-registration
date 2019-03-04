using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Contracts {
    public interface IParticipantRepository {
        Task<Participant> Add(Participant participant);
        IEnumerable<Participant> GetAll();
        Task<Participant> Find(int id);
        Task<Participant> Remove(int id);
        Task<Participant> Update(Participant participant);
        Task<bool> Exists(int id);
    }
}