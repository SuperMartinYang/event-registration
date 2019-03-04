using System.Collections.Generic;
using System.Threading.Tasks;
using event_registration.Models;

namespace event_registration.Contracts {
    public interface IFormRepository {
        Task<Form> Add(Form form);
        IEnumerable<Form> GetAll();
        Task<Form> Find(int id);
        Task<Form> Remove(int id);
        Task<Form> Update(Form form);
        Task<bool> Exists(int id);
    }
}