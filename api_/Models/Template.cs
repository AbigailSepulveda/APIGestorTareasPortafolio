using System.Collections.Generic;

namespace api_.Models {
    public class Template {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int state { get; set; }
        public List<TemplateTask> tasks { get; set; }
        public long userId { get; set; }
        public int n_tasks { get; set; }
    }
}