using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class ProcessDAL {

        public ProcessDAL() {
            // default
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<process> fetchAllByUnit(decimal unit_id) {
            using (var conn = new db_entities()) {
                try {
                    var users = conn.users.Where(x => x.unit_id == unit_id).Select(x => x.id).ToList();

                    return conn.process.Where(r => users.Contains(r.user_id)).ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static process getById(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.process.Where(r => r.id == id).FirstOrDefault();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static decimal insert(string name, string description, DateTime start, decimal userId) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_PROCESS_INSERT(name, description, DateTime.Now, start, userId); ;

                    var process = conn.process.Where(x => x.name.Equals(name)
                    && x.description.Equals(description)
                    && x.user_id == userId).FirstOrDefault();

                    return process.id;
                } catch (Exception e) {
                    throw e;
                }
            }
        }


    }
}
