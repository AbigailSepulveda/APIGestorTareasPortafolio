using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class RolModuleDAL {

        public RolModuleDAL() {
            // default
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<roles_modules> fetchAll() {
            using (var conn = new db()) {
                try {
                    return conn.roles_modules.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
