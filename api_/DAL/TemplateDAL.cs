using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class TemplateDAL {

        public TemplateDAL() {
            // default
        }

        /**
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String name) {
            using (var conn = new db_entities()) {
                try {
                    var result = conn.templates.Where(x => x.name.Equals(name)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String name, String description, List<templates_tasks> tasks, long userId) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_TEMPLATE_INSERT(name, description, DateTime.Now, 1, userId);

                    var entity = conn.templates.Where(x => x.name == name).FirstOrDefault();

                    foreach (templates_tasks tt in tasks) {
                        conn.SP_TEMPLATE_TASK_INSERT(tt.name, tt.description, entity.id, tt.task_status_code, DateTime.Now, tt.end_date, userId);
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String name, String description, int state, List<templates_tasks> tasks, long userId) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_TEMPLATE_UPDATE(id, name, description, DateTime.Now, state, userId);

                    // removemos los items
                    foreach (templates_tasks tt in conn.templates_tasks.Where(x => x.template_id == id).ToList()) {
                        conn.templates_tasks.Remove(tt);
                    }
                    conn.SaveChanges();

                    // agregamos las actualizaciones
                    foreach (templates_tasks tt in tasks) {
                        conn.SP_TEMPLATE_TASK_INSERT(tt.name, tt.description, id, tt.task_status_code, DateTime.Now, tt.end_date, userId);
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<templates> fetchAll() {
            using (var conn = new db_entities()) {
                try {
                    return conn.templates.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static List<templates> fetchAllByUnit(decimal unit_id) {
            using (var conn = new db_entities()) {
                try {
                    var users = conn.users.Where(x => x.unit_id == unit_id).Select(x => x.id).ToList();

                    return conn.templates.Where(r => users.Contains(r.user_id)).ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
