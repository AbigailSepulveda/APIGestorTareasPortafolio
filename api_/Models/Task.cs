using System;
using System.Collections.Generic;

namespace api_.Models {
    public class Task {
        public long id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public long creatorUserId { get; set; }
        public User creatorUser { get; set; }
        public DateTime? dateStart { get; set; }
        public DateTime? dateEnd { get; set; }
        public String sDateStart { get; set; }
        public String sDateEnd { get; set; }
        public String taskStatusId { get; set; }
        public TaskStatus taskStatus { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public long fatherTaksId { get; set; }
        public long processId { get; set; }
        public Process process { get; set; }
        public Document document { get; set; }
        public List<Document> documents { get; set; }
        public long assingId { get; set; }
    }
}