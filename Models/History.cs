namespace event_registration.Models {
    public class History {
        [Required]
        public int id { get; set; }
        [Required]
        public int event_id { get; set; }
        [Required]
        public string operator { get; set; }
        [Required]
        [Timestamp]
        public byte[] action_time { get; set; }
        [Required]
        public string action { get; set; }
    }
}