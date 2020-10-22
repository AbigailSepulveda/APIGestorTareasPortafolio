using System;

namespace api_.Models {
    public class Unit {
        public long id { get; set; }
        public string name { get; set; }
        public int state { get; set; }
        public Decimal? boss_id { get; set; }
        public User boss { get; set; }
        public Enterprise enterprise { get; set; }
        public long enterprise_id { get; set; }
    }
}