using System;
using System.Collections.Generic;

namespace api_.Request {
    public class RolUpdateRequest {
        public long id { get; set; }
        public String name { get; set; }
        public int state { get; set; }
        public List<long> modules { get; set; }
    }
}