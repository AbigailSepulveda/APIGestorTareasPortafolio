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
    
    public partial class process
    {
        public process()
        {
            this.tasks = new HashSet<tasks>();
        }
    
        public decimal id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<decimal> state { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual ICollection<tasks> tasks { get; set; }
    }
}