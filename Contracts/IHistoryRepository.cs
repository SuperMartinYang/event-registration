namespace event_registration.Contracts {
    public interface IHistoryRepository {
        Task<History> Add(History history);
        IEumerable<History> GetAll();
        Task<History> Find(int id);
        Task<History> Remove(int id);
        Task<History> Update(History history);
        Task<bool> Exists(int id);
    }
}