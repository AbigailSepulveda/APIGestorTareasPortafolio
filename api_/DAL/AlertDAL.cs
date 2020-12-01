using api_.DB;
using api_.Exceptions;
using System;
using System.Linq;

namespace api_.DAL {
    public class AlertDAL {

        public AlertDAL() {
            // default
        }

        public static alerts fetchByTaskId(long id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.alerts.Where(x => x.task_id == id && x.state == 0).FirstOrDefault();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String message, decimal id) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_ALERT_INSERT(message, id, DateTime.Now, 0);
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, decimal taskId, String message, decimal state) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.alerts.Where(x => x.id == id).FirstOrDefault();
                    if (entity == null) {
                        throw new NotExistsException();
                    } else {
                        conn.SP_ALERT_UPDATE(id, message, taskId, DateTime.Now, state);
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
