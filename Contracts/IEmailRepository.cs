namespace event_registration.Contracts {
    public interface IEmailRepository {
        Task<Email> Add(Email email);
        IEumerable<Email> GetAll();
        Task<Email> Find(int id);
        Task<Email> Remove(int id);
        Task<Email> Update(Email email);
        Task<bool> Exists(int id);
    }
}