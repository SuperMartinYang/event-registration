namespace event_registration.Contracts {
    public interface IEventRepository {
        Task<Event> Add(Event event);
        IEumerable<Event> GetAll();
        Task<Event> Find(int id);
        Task<Event> Remove(int id);
        Task<Event> Update(Event event);
        Task<bool> Exists(int id);
    }
}