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
    
    public partial class enterprises
    {
        public enterprises()
        {
            this.users = new HashSet<users>();
        }
    
        public decimal id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> update_at { get; set; }
        public Nullable<short> state { get; set; }
    
        public virtual ICollection<users> users { get; set; }
    }
}
