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
         * Método para crear nuevo registro
         */
        public static void insert(String name) {
            using (var conn = new db()) {
                try {
                    enterprises entity = new enterprises();
                    entity.name = name;
                    entity.created_at = new DateTime();
                    conn.enterprises.Add(entity);
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String name) {
            using (var conn = new db()) {
                try {
                    var entity = conn.enterprises.Where(x => x.id == id).FirstOrDefault();
                    entity.name = name;
                    entity.update_at = new DateTime();
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<enterprises> fetchAll() {
            using (var conn = new db()) {
                try {
                    return conn.enterprises.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
