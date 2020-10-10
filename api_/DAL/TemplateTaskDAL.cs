using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class TemplateTaskDAL {

        public TemplateTaskDAL() {
            // default
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<templates_tasks> fetchAll() {
            using (var conn = new db_entities()) {
                try {
                    return conn.templates_tasks.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
