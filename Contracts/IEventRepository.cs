using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Contracts {
    public interface IEventRepository {
        Task<Event> Add(Event ev);
        IEnumerable<Event> GetAll();
        Task<Event> Find(int id);
        Task<Event> Remove(int id);
        Task<Event> Update(Event ev);
        Task<bool> Exists(int id);
    }
}