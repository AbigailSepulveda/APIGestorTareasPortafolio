using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class RolDAL {

        public RolDAL() {
            // default
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String name, List<modules> modules) {
            using (var conn = new db()) {
                try {
                    roles entity = new roles();
                    entity.name = name;
                    entity.created_at = new DateTime();
                    conn.roles.Add(entity);
                    conn.SaveChanges();

                    foreach (modules item in modules) {
                        roles_modules rm = new roles_modules();
                        rm.module_id = item.id;
                        rm.rol_id = entity.id;
                        conn.roles_modules.Add(rm);
                    }
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(Int32 id, String name, List<modules> modules) {
            using (var conn = new db()) {
                try {
                    var entity = conn.roles.Where(x => x.id == id).FirstOrDefault();
                    entity.name = name;
                    entity.updated_at = new DateTime();
                    conn.SaveChanges();

                    // removemos los items
                    foreach (roles_modules rm in conn.roles_modules.Where(x => x.rol_id == entity.id).ToList()) {
                        conn.roles_modules.Remove(rm);
                    }

                    // agregamos las actualizaciones
                    foreach (modules item in modules) {
                        roles_modules rm = new roles_modules();
                        rm.module_id = item.id;
                        rm.rol_id = entity.id;
                        conn.roles_modules.Add(rm);
                    }

                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<roles> fetchAll() {
            using (var conn = new db()) {
                try {
                    return conn.roles.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
