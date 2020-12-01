using System;

namespace api_.Models {
    public class Alert {
        public decimal id { get; set; }
        public String message { get; set; }
        public int state { get; set; }
        public Task task { get; set; }
    }
}