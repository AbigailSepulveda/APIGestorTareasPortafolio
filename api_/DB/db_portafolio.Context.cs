﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class db_entities : DbContext
    {
        public db_entities()
            : base("name=db_entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<alerts> alerts { get; set; }
        public DbSet<config_devices> config_devices { get; set; }
        public DbSet<config_traffic_lights> config_traffic_lights { get; set; }
        public DbSet<enterprises> enterprises { get; set; }
        public DbSet<files> files { get; set; }
        public DbSet<log_assing_task> log_assing_task { get; set; }
        public DbSet<log_task> log_task { get; set; }
        public DbSet<messages> messages { get; set; }
        public DbSet<modules> modules { get; set; }
        public DbSet<process> process { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<roles_modules> roles_modules { get; set; }
        public DbSet<task_statuses> task_statuses { get; set; }
        public DbSet<tasks> tasks { get; set; }
        public DbSet<tasks_relations> tasks_relations { get; set; }
        public DbSet<templates> templates { get; set; }
        public DbSet<templates_tasks> templates_tasks { get; set; }
        public DbSet<types_alerts> types_alerts { get; set; }
        public DbSet<units> units { get; set; }
        public DbSet<users> users { get; set; }
    
        public virtual int SP_CONFIG_TRAFFIC_LIGHTS_UPDATE(Nullable<decimal> p_ID, Nullable<decimal> p_GREEN, Nullable<decimal> p_YELLOW, Nullable<decimal> p_RED, Nullable<System.DateTime> p_UPDATED_AT)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_GREENParameter = p_GREEN.HasValue ?
                new ObjectParameter("P_GREEN", p_GREEN) :
                new ObjectParameter("P_GREEN", typeof(decimal));
    
            var p_YELLOWParameter = p_YELLOW.HasValue ?
                new ObjectParameter("P_YELLOW", p_YELLOW) :
                new ObjectParameter("P_YELLOW", typeof(decimal));
    
            var p_REDParameter = p_RED.HasValue ?
                new ObjectParameter("P_RED", p_RED) :
                new ObjectParameter("P_RED", typeof(decimal));
    
            var p_UPDATED_ATParameter = p_UPDATED_AT.HasValue ?
                new ObjectParameter("P_UPDATED_AT", p_UPDATED_AT) :
                new ObjectParameter("P_UPDATED_AT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CONFIG_TRAFFIC_LIGHTS_UPDATE", p_IDParameter, p_GREENParameter, p_YELLOWParameter, p_REDParameter, p_UPDATED_ATParameter);
        }
    
        public virtual int SP_ENTERPRISE_INSERT(string p_NAME, Nullable<System.DateTime> p_CREATE_AT, Nullable<decimal> p_STATE)
        {
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_CREATE_ATParameter = p_CREATE_AT.HasValue ?
                new ObjectParameter("P_CREATE_AT", p_CREATE_AT) :
                new ObjectParameter("P_CREATE_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ENTERPRISE_INSERT", p_NAMEParameter, p_CREATE_ATParameter, p_STATEParameter);
        }
    
        public virtual int SP_ENTERPRISE_UPDATE(Nullable<decimal> p_ID, string p_NAME, Nullable<System.DateTime> p_UPDATE_AT, Nullable<decimal> p_STATE)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_UPDATE_ATParameter = p_UPDATE_AT.HasValue ?
                new ObjectParameter("P_UPDATE_AT", p_UPDATE_AT) :
                new ObjectParameter("P_UPDATE_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ENTERPRISE_UPDATE", p_IDParameter, p_NAMEParameter, p_UPDATE_ATParameter, p_STATEParameter);
        }
    
        public virtual int SP_ROL_INSERT(string p_NAME, Nullable<System.DateTime> p_CREATE_AT, Nullable<decimal> p_STATE)
        {
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_CREATE_ATParameter = p_CREATE_AT.HasValue ?
                new ObjectParameter("P_CREATE_AT", p_CREATE_AT) :
                new ObjectParameter("P_CREATE_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ROL_INSERT", p_NAMEParameter, p_CREATE_ATParameter, p_STATEParameter);
        }
    
        public virtual int SP_ROL_MODULE_INSERT(Nullable<decimal> p_ROL_ID, Nullable<decimal> p_MODULE_ID)
        {
            var p_ROL_IDParameter = p_ROL_ID.HasValue ?
                new ObjectParameter("P_ROL_ID", p_ROL_ID) :
                new ObjectParameter("P_ROL_ID", typeof(decimal));
    
            var p_MODULE_IDParameter = p_MODULE_ID.HasValue ?
                new ObjectParameter("P_MODULE_ID", p_MODULE_ID) :
                new ObjectParameter("P_MODULE_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ROL_MODULE_INSERT", p_ROL_IDParameter, p_MODULE_IDParameter);
        }
    
        public virtual int SP_ROL_UPDATE(Nullable<decimal> p_ID, string p_NAME, Nullable<System.DateTime> p_UPDATE_AT, Nullable<decimal> p_STATE)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_UPDATE_ATParameter = p_UPDATE_AT.HasValue ?
                new ObjectParameter("P_UPDATE_AT", p_UPDATE_AT) :
                new ObjectParameter("P_UPDATE_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ROL_UPDATE", p_IDParameter, p_NAMEParameter, p_UPDATE_ATParameter, p_STATEParameter);
        }
    
        public virtual int SP_UNIT_INSERT(string p_NAME, Nullable<System.DateTime> p_CREATE_AT, Nullable<decimal> p_STATE, Nullable<decimal> p_BOSS)
        {
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_CREATE_ATParameter = p_CREATE_AT.HasValue ?
                new ObjectParameter("P_CREATE_AT", p_CREATE_AT) :
                new ObjectParameter("P_CREATE_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            var p_BOSSParameter = p_BOSS.HasValue ?
                new ObjectParameter("P_BOSS", p_BOSS) :
                new ObjectParameter("P_BOSS", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UNIT_INSERT", p_NAMEParameter, p_CREATE_ATParameter, p_STATEParameter, p_BOSSParameter);
        }
    
        public virtual int SP_UNIT_UPDATE(Nullable<decimal> p_ID, string p_NAME, Nullable<System.DateTime> p_UPDATED_AT, Nullable<decimal> p_STATE, Nullable<decimal> p_BOSS)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_UPDATED_ATParameter = p_UPDATED_AT.HasValue ?
                new ObjectParameter("P_UPDATED_AT", p_UPDATED_AT) :
                new ObjectParameter("P_UPDATED_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            var p_BOSSParameter = p_BOSS.HasValue ?
                new ObjectParameter("P_BOSS", p_BOSS) :
                new ObjectParameter("P_BOSS", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UNIT_UPDATE", p_IDParameter, p_NAMEParameter, p_UPDATED_ATParameter, p_STATEParameter, p_BOSSParameter);
        }
    
        public virtual int SP_USER_INSERT(string p_NAME, string p_EMAIL, string p_PASSWORD, Nullable<decimal> p_ROL_ID, Nullable<decimal> p_UNIT_ID, Nullable<System.DateTime> p_CREATED_AT, Nullable<decimal> p_STATE, Nullable<decimal> p_ENTERPRISE_ID)
        {
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_EMAILParameter = p_EMAIL != null ?
                new ObjectParameter("P_EMAIL", p_EMAIL) :
                new ObjectParameter("P_EMAIL", typeof(string));
    
            var p_PASSWORDParameter = p_PASSWORD != null ?
                new ObjectParameter("P_PASSWORD", p_PASSWORD) :
                new ObjectParameter("P_PASSWORD", typeof(string));
    
            var p_ROL_IDParameter = p_ROL_ID.HasValue ?
                new ObjectParameter("P_ROL_ID", p_ROL_ID) :
                new ObjectParameter("P_ROL_ID", typeof(decimal));
    
            var p_UNIT_IDParameter = p_UNIT_ID.HasValue ?
                new ObjectParameter("P_UNIT_ID", p_UNIT_ID) :
                new ObjectParameter("P_UNIT_ID", typeof(decimal));
    
            var p_CREATED_ATParameter = p_CREATED_AT.HasValue ?
                new ObjectParameter("P_CREATED_AT", p_CREATED_AT) :
                new ObjectParameter("P_CREATED_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            var p_ENTERPRISE_IDParameter = p_ENTERPRISE_ID.HasValue ?
                new ObjectParameter("P_ENTERPRISE_ID", p_ENTERPRISE_ID) :
                new ObjectParameter("P_ENTERPRISE_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_USER_INSERT", p_NAMEParameter, p_EMAILParameter, p_PASSWORDParameter, p_ROL_IDParameter, p_UNIT_IDParameter, p_CREATED_ATParameter, p_STATEParameter, p_ENTERPRISE_IDParameter);
        }
    
        public virtual int SP_USER_UPDATE_WITHOUT_PASSWORD(Nullable<decimal> p_ID, string p_NAME, string p_EMAIL, Nullable<decimal> p_ROL_ID, Nullable<decimal> p_UNIT_ID, Nullable<System.DateTime> p_UPDATED_AT, Nullable<decimal> p_STATE, Nullable<decimal> p_ENTERPRISE_ID)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_EMAILParameter = p_EMAIL != null ?
                new ObjectParameter("P_EMAIL", p_EMAIL) :
                new ObjectParameter("P_EMAIL", typeof(string));
    
            var p_ROL_IDParameter = p_ROL_ID.HasValue ?
                new ObjectParameter("P_ROL_ID", p_ROL_ID) :
                new ObjectParameter("P_ROL_ID", typeof(decimal));
    
            var p_UNIT_IDParameter = p_UNIT_ID.HasValue ?
                new ObjectParameter("P_UNIT_ID", p_UNIT_ID) :
                new ObjectParameter("P_UNIT_ID", typeof(decimal));
    
            var p_UPDATED_ATParameter = p_UPDATED_AT.HasValue ?
                new ObjectParameter("P_UPDATED_AT", p_UPDATED_AT) :
                new ObjectParameter("P_UPDATED_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            var p_ENTERPRISE_IDParameter = p_ENTERPRISE_ID.HasValue ?
                new ObjectParameter("P_ENTERPRISE_ID", p_ENTERPRISE_ID) :
                new ObjectParameter("P_ENTERPRISE_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_USER_UPDATE_WITHOUT_PASSWORD", p_IDParameter, p_NAMEParameter, p_EMAILParameter, p_ROL_IDParameter, p_UNIT_IDParameter, p_UPDATED_ATParameter, p_STATEParameter, p_ENTERPRISE_IDParameter);
        }
    
        public virtual int SP_USER_UPDATE_WITH_PASSWORD(Nullable<decimal> p_ID, string p_NAME, string p_EMAIL, string p_PASSWORD, Nullable<decimal> p_ROL_ID, Nullable<decimal> p_UNIT_ID, Nullable<System.DateTime> p_UPDATED_AT, Nullable<decimal> p_STATE, Nullable<decimal> p_ENTERPRISE_ID)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_EMAILParameter = p_EMAIL != null ?
                new ObjectParameter("P_EMAIL", p_EMAIL) :
                new ObjectParameter("P_EMAIL", typeof(string));
    
            var p_PASSWORDParameter = p_PASSWORD != null ?
                new ObjectParameter("P_PASSWORD", p_PASSWORD) :
                new ObjectParameter("P_PASSWORD", typeof(string));
    
            var p_ROL_IDParameter = p_ROL_ID.HasValue ?
                new ObjectParameter("P_ROL_ID", p_ROL_ID) :
                new ObjectParameter("P_ROL_ID", typeof(decimal));
    
            var p_UNIT_IDParameter = p_UNIT_ID.HasValue ?
                new ObjectParameter("P_UNIT_ID", p_UNIT_ID) :
                new ObjectParameter("P_UNIT_ID", typeof(decimal));
    
            var p_UPDATED_ATParameter = p_UPDATED_AT.HasValue ?
                new ObjectParameter("P_UPDATED_AT", p_UPDATED_AT) :
                new ObjectParameter("P_UPDATED_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            var p_ENTERPRISE_IDParameter = p_ENTERPRISE_ID.HasValue ?
                new ObjectParameter("P_ENTERPRISE_ID", p_ENTERPRISE_ID) :
                new ObjectParameter("P_ENTERPRISE_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_USER_UPDATE_WITH_PASSWORD", p_IDParameter, p_NAMEParameter, p_EMAILParameter, p_PASSWORDParameter, p_ROL_IDParameter, p_UNIT_IDParameter, p_UPDATED_ATParameter, p_STATEParameter, p_ENTERPRISE_IDParameter);
        }
    
        public virtual int SP_TEMPLATE_INSERT(string p_NAME, string p_DESCRIPTION, Nullable<System.DateTime> p_CREATE_AT, Nullable<decimal> p_STATE)
        {
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_DESCRIPTIONParameter = p_DESCRIPTION != null ?
                new ObjectParameter("P_DESCRIPTION", p_DESCRIPTION) :
                new ObjectParameter("P_DESCRIPTION", typeof(string));
    
            var p_CREATE_ATParameter = p_CREATE_AT.HasValue ?
                new ObjectParameter("P_CREATE_AT", p_CREATE_AT) :
                new ObjectParameter("P_CREATE_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_TEMPLATE_INSERT", p_NAMEParameter, p_DESCRIPTIONParameter, p_CREATE_ATParameter, p_STATEParameter);
        }
    
        public virtual int SP_TEMPLATE_UPDATE(Nullable<decimal> p_ID, string p_NAME, string p_DESCRIPTION, Nullable<System.DateTime> p_UPDATED_AT, Nullable<decimal> p_STATE)
        {
            var p_IDParameter = p_ID.HasValue ?
                new ObjectParameter("P_ID", p_ID) :
                new ObjectParameter("P_ID", typeof(decimal));
    
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_DESCRIPTIONParameter = p_DESCRIPTION != null ?
                new ObjectParameter("P_DESCRIPTION", p_DESCRIPTION) :
                new ObjectParameter("P_DESCRIPTION", typeof(string));
    
            var p_UPDATED_ATParameter = p_UPDATED_AT.HasValue ?
                new ObjectParameter("P_UPDATED_AT", p_UPDATED_AT) :
                new ObjectParameter("P_UPDATED_AT", typeof(System.DateTime));
    
            var p_STATEParameter = p_STATE.HasValue ?
                new ObjectParameter("P_STATE", p_STATE) :
                new ObjectParameter("P_STATE", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_TEMPLATE_UPDATE", p_IDParameter, p_NAMEParameter, p_DESCRIPTIONParameter, p_UPDATED_ATParameter, p_STATEParameter);
        }
    
        public virtual int SP_TEMPLATE_TASK_INSERT(string p_NAME, string p_DESCRIPTION, Nullable<System.DateTime> p_DATE_START, Nullable<System.DateTime> p_DATE_END, Nullable<decimal> p_TEMPLATE_ID, string p_TASK_STATUS_CODE, Nullable<System.DateTime> p_CREATE_AT)
        {
            var p_NAMEParameter = p_NAME != null ?
                new ObjectParameter("P_NAME", p_NAME) :
                new ObjectParameter("P_NAME", typeof(string));
    
            var p_DESCRIPTIONParameter = p_DESCRIPTION != null ?
                new ObjectParameter("P_DESCRIPTION", p_DESCRIPTION) :
                new ObjectParameter("P_DESCRIPTION", typeof(string));
    
            var p_DATE_STARTParameter = p_DATE_START.HasValue ?
                new ObjectParameter("P_DATE_START", p_DATE_START) :
                new ObjectParameter("P_DATE_START", typeof(System.DateTime));
    
            var p_DATE_ENDParameter = p_DATE_END.HasValue ?
                new ObjectParameter("P_DATE_END", p_DATE_END) :
                new ObjectParameter("P_DATE_END", typeof(System.DateTime));
    
            var p_TEMPLATE_IDParameter = p_TEMPLATE_ID.HasValue ?
                new ObjectParameter("P_TEMPLATE_ID", p_TEMPLATE_ID) :
                new ObjectParameter("P_TEMPLATE_ID", typeof(decimal));
    
            var p_TASK_STATUS_CODEParameter = p_TASK_STATUS_CODE != null ?
                new ObjectParameter("P_TASK_STATUS_CODE", p_TASK_STATUS_CODE) :
                new ObjectParameter("P_TASK_STATUS_CODE", typeof(string));
    
            var p_CREATE_ATParameter = p_CREATE_AT.HasValue ?
                new ObjectParameter("P_CREATE_AT", p_CREATE_AT) :
                new ObjectParameter("P_CREATE_AT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_TEMPLATE_TASK_INSERT", p_NAMEParameter, p_DESCRIPTIONParameter, p_DATE_STARTParameter, p_DATE_ENDParameter, p_TEMPLATE_IDParameter, p_TASK_STATUS_CODEParameter, p_CREATE_ATParameter);
        }
    }
}
