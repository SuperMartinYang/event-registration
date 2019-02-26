namespace event_registration.Models {
    public class Email {
        // columns 
        [Required]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string content { get; set; }
    }
}