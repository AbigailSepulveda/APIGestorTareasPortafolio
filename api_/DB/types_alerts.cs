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
    
    public partial class types_alerts
    {
        public types_alerts()
        {
            this.alerts = new HashSet<alerts>();
        }
    
        public decimal id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<decimal> state { get; set; }
    
        public virtual ICollection<alerts> alerts { get; set; }
    }
}
