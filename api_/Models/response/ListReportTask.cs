﻿namespace api_.Models.response {
    public class ListReportTask {
        public int tasks { get; set; }
        public int pending { get; set; }
        public int working { get; set; }
        public int done { get; set; }
    }
}