﻿using System;

namespace api_.Models {
    public class Process {
        public long id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public long task_status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime finished { get; set; }
        public long user_id { get; set; }
        public int n_tasks { get; set; }
    }
}