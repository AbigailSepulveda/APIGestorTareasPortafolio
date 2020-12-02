using System;

namespace api_.Models.response {
    public class ListReportUnit {
        public int unitId { get; set; }
        public String unitName { get; set; }
        public int pending { get; set; }
        public int working { get; set; }
        public int done { get; set; }
    }
}