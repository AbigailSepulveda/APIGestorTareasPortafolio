using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class EnterpriseDAL {

        public EnterpriseDAL() {
            // default
        }

        /**
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String name) {
            using (var conn = new db_entities()) {
                try {
                    var result = conn.enterprises.Where(x => x.name.Equals(name)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String name) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_ENTERPRISE_INSERT(name, DateTime.Now, 1);
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String name, int state) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_ENTERPRISE_UPDATE(id, name, DateTime.Now, state);
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<enterprises> fetchAll() {
            using (var conn = new db_entities()) {
                try {
                    return conn.enterprises.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
