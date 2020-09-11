using System;

namespace api_.Models {
    public class User {
        public decimal id { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public decimal rol_id { get; set; }
        public decimal? unit_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public decimal? state { get; set; }
        public String token_session { get; set; }
        public decimal? enterprise_id { get; set; }
    }
}