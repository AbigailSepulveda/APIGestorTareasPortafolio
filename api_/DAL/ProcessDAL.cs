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
        public static List<process> fetchAllByUser(decimal id) {
            using (var conn = new db_entities()) {
                try {

                    var user = conn.users.Where(x => x.id == id).FirstOrDefault();
                    decimal? unitId = null;
                    if (user != null) {
                        unitId = user.unit_id;
                        var users = conn.users.Where(x => x.unit_id == unitId).Select(y => y.id).ToList();

                        if (users != null && users.Count() > 0) {
                            return conn.process.Where(x => users.Contains(x.id)).ToList();
                        } else {
                            return new List<process>();
                        }
                    } else {
                        return new List<process>();
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
