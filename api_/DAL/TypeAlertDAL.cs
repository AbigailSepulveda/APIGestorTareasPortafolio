using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class TypeAlertDAL {

        public TypeAlertDAL() {
            // default
        }

        /**
         * Método para registrar nuevo tpo de alerta
         */
        public static void insert(String name) {
            using (var conn = new db()) {
                try {
                    types_alerts entity = new types_alerts();
                    entity.name = name;
                    entity.state = 1;
                    entity.created_at = new DateTime();
                    conn.types_alerts.Add(entity);
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el tipo de alerta
         */
        public static void update(decimal id, String name, int state) {
            using (var conn = new db()) {
                try {
                    var entity = conn.types_alerts.Where(x => x.id == id).FirstOrDefault();
                    entity.name = name;
                    entity.state = state;
                    entity.updated_at = new DateTime();
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros activos
         */
        public static List<types_alerts> fetchAll() {
            using (var conn = new db()) {
                try {
                    var result = conn.types_alerts.Where(x => x.state == 1).ToList();
                    if (result != null) {
                        return result;
                    }
                    return new List<types_alerts>();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
