namespace event_registration.Models {
    public class Paticipant {
        [Required]
        public int id { get; set; }
        [Required]
        public int event_id { get; set; }
        [Required]
        public string answers { get; set; }
        [Required]
        public int priority { get; set; }
    }
}