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
    
    public partial class units
    {
        public units()
        {
            this.users = new HashSet<users>();
        }
    
        public decimal id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<decimal> state { get; set; }
        public Nullable<decimal> boss { get; set; }
        public Nullable<decimal> enterprise_id { get; set; }
    
        public virtual enterprises enterprises { get; set; }
        public virtual ICollection<users> users { get; set; }
    }
}
