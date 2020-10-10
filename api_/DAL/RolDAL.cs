using api_.DB;
using api_.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class RolDAL {

        public RolDAL() {
            // default
        }

        /**
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String name) {
            using (var conn = new db_entities()) {
                try {
                    var result = conn.roles.Where(x => x.name.Equals(name)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String name, List<long> modules) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_ROL_INSERT(name, DateTime.Now, 1);
                    var entity = conn.roles.Where(x => x.name == name).FirstOrDefault();
                    if (modules != null) {
                        foreach (long item in modules) {
                            conn.SP_ROL_MODULE_INSERT(entity.id, item);
                        }
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String name, int state, List<long> modules) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.roles.Where(x => x.id == id).FirstOrDefault();

                    if (entity == null) {
                        throw new NotExistsException();
                    } else {
                        conn.SP_ROL_UPDATE(id, name, DateTime.Now, state);

                        // removemos los items
                        foreach (roles_modules rm in conn.roles_modules.Where(x => x.rol_id == entity.id).ToList()) {
                            conn.roles_modules.Remove(rm);
                        }

                        // agregamos las actualizaciones
                        foreach (long item in modules) {
                            conn.SP_ROL_MODULE_INSERT(entity.id, item);
                        }
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
            using (var conn = new db_entities()) {
                try {
                    return conn.roles.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
