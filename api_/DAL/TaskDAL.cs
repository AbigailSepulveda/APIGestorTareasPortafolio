using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class TaskDAL {

        public TaskDAL() {
            // default
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<tasks> fetchAllByUser(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.tasks.Where(x => x.creator_user_id == id).ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
