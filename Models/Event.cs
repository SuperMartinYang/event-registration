namespace event_registration.Models {
    public class Event {
        // properties (columns)
        [Required]
        public int id { get; set; }
        [Required]
        public int form_id { get; set; }
        [Required]
        public int user_id { get; set; }

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

    }
}