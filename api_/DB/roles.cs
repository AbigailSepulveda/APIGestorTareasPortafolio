//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api_.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class roles
    {
        public roles()
        {
            this.roles_modules = new HashSet<roles_modules>();
            this.users = new HashSet<users>();
        }
    
        public decimal id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<decimal> state { get; set; }
    
        public virtual ICollection<roles_modules> roles_modules { get; set; }
        public virtual ICollection<users> users { get; set; }
    }
}
