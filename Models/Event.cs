namespace event_registration.Models {
    public class Event {
        // properties (columns)
        [Required]
        public int id { get; set; }
        [Required]
        [ForeignKey("Form")]
        public int form_id { get; set; }
        public Form Form { get; set; }
        [Required]
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string description { get; set; }
        public string category { get; set; }
        [Required]
        [Timestamp]
        public byte[] start_time { get; set; }
        [Required]
        [Timestamp]
        public byte[] end_time { get; set; }
        [Required]
        public int seat { get; set; }

        public ICollection<History> Histories { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}