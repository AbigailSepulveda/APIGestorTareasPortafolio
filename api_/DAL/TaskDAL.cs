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
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String name) {
            using (var conn = new db_entities()) {
                try {
                    var result = conn.tasks.Where(x => x.name.Equals(name)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
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
        public static tasks fetchById(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.tasks.Where(x => x.id == id).FirstOrDefault();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static decimal createTask(tasks tasks) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_TASK_INSERT(tasks.name, tasks.description, tasks.process_id, tasks.father_taks_id, tasks.task_status, tasks.date_start, tasks.date_end, DateTime.Now, tasks.creator_user_id, tasks.assing_id);
                    var result = conn.tasks.Where(x => x.name == tasks.name 
                    && x.description == tasks.description 
                    && x.creator_user_id == tasks.creator_user_id).FirstOrDefault();

                    if (result != null) {
                        return result.id;
                    } else {
                        return -1;
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
