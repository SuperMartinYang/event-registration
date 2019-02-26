namespace event_registration.Contracts {
    public interface IParticipantRepository {
        Task<Participant> Add(Participant participant);
        IEumerable<Participant> GetAll();
        Task<Participant> Find(int id);
        Task<Participant> Remove(int id);
        Task<Participant> Update(Participant participant);
        Task<bool> Exists(int id);
    }
}