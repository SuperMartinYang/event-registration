namespace event_registration.Models {
    public class ERDbContext : DbContext {
        // init
        public ERDbContext(DbContextOptions<ERDbContext> options) : base(options){
            Database.EnsureCreated();
        }

        public DbSet<Event> Events { get; set; };
        public DbSet<Paticipant> Paticipants { get; set; };
        public DbSet<Form> Forms { get; set; };
        public DbSet<User> Users { get; set; };
        public DbSet<Email> Emails { get; set; };
        public DbSet<History> Histories { get; set; };
    }
}