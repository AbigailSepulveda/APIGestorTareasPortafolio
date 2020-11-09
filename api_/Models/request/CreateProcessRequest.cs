using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_.Models.request {
    public class CreateProcessRequest {
        public string name { get; set; }
        public string description { get; set; }
        public int[] tasks { get; set; }
        public long user_id { get; set; }
    }
}