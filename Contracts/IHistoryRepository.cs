using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Contracts {
    public interface IHistoryRepository {
        Task<History> Add(History history);
        IEnumerable<History> GetAll();
        Task<History> Find(int id);
        Task<History> Remove(int id);
        Task<History> Update(History history);
        Task<bool> Exists(int id);
    }
}