﻿using System;

namespace api_.Models {
    public class UserLogin {
        public decimal id { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public Rol rol { get; set; }
        public Unit unit { get; set; }
        public decimal? state { get; set; }
        public String token_session { get; set; }
        public Enterprise enterprise { get; set; }
    }
}