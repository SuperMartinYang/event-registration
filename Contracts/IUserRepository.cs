using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Contracts {
    public interface IUserRepository {
        Task<User> Add(User user);
        IEnumerable<User> GetAll();
        Task<User> Find(int id);
        Task<User> Remove(int id);
        Task<User> Update(User user);
        Task<bool> Exists(int id);
    }
}