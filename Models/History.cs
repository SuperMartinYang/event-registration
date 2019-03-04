using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace event_registration.Models {
    public class History {
        [Required]
        public int id { get; set; }
        [Required]
        [ForeignKey("Event")]
        public int event_id { get; set; }
        public Event Event { get; set; }
        [Required]
        public string oper { get; set; }
        [Required]
        [Timestamp]
        public byte[] action_time { get; set; }
        [Required]
        public string action { get; set; }
    }
}