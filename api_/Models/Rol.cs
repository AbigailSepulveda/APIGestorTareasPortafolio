using System.Collections.Generic;

namespace api_.Models {
    public class Rol {
        public decimal id { get; set; }
        public string name { get; set; }
        public List<Module> modules { get; set; }
    }
}