using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace event_registration.Models {
    public class User {
        [Required]
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string phone_no { get; set; }

        public ICollection<Event> Events { get; set; }
    }    
}