using System;

namespace api_.Exceptions {
    public class ExistsException : Exception {
        public ExistsException() : base("Registro ya Existe") {
        }
    }
}