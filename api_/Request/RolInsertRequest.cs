using System;
using System.Collections.Generic;

namespace api_.Request {
    public class RolInsertRequest {
        public String name { get; set; }
        public List<long> modules { get; set; }
    }
}