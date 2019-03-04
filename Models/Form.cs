namespace event_registration.Models {
    public class Form {
        [Required]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [NotMapped]
        public Field[] fields { 
            get {
                var ser = new JsonSerializer();
                var jr = new JsonTextReader(new StringBuilder(fields_json));
                return ser.Deserialize<Field[]>(jr);
            } 
            set {
                var ser = new JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                fields_json = sw.ToString();
            } 
        }

        [Required]
        public string fields_json { get; set; }

        [Required]
        [Timestamp]
        public byte[] create_time { get; set; } 

        public ICollection<Event> Events { get; set; }
    }

    public class Field {
        public string type { get; set; }
        public string name { get; set; }
        public string[] options { get; set; }
    }
}