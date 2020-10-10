namespace api_.Models {
    public class Unit {
        public long id { get; set; }
        public string name { get; set; }
        public int state { get; set; }
        public long boss_id { get; set; }
        public User boss { get; set; }
    }
}