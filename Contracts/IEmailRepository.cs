using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Contracts {
    public interface IEmailRepository {
        Task<Email> Add(Email email);
        IEnumerable<Email> GetAll();
        Task<Email> Find(int id);
        Task<Email> Remove(int id);
        Task<Email> Update(Email email);
        Task<bool> Exists(int id);
    }
}