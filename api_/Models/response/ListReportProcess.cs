using System;
using System.Collections.Generic;

namespace api_.Models.response {
    public class ListReportProcess {
        public int processId { get; set; }
        public String processName { get; set; }
        public List<Task> taskList { get; set; }
        public int tasks { get; set; }
        public int pending { get; set; }
        public int working { get; set; }
        public int done { get; set; }
    }
}