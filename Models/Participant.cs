using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace event_registration.Models {
    public class Participant {
        [Required]
        public int id { get; set; }
        [Required]
        [ForeignKey("Event")]
        public int event_id { get; set; }
        public Event Event { get; set; }
        [Required]
        public string answers { get; set; }
        [Required]
        public int priority { get; set; }
    }
}