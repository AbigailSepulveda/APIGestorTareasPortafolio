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
        public static List<tasks> getAssignTasksByUser(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.tasks.Where(x => x.assing_id == id && x.task_status == "0").ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
        public static List<tasks> getTasksByProcessId(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.tasks.Where(x => x.process_id == id).ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
        public static List<tasks> fetchAllByUnit(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    var users = conn.users.Where(x => x.unit_id == id).Select(x => x.id).ToList();

                    return conn.tasks.Where(r => users.Contains(r.creator_user_id)).ToList();
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
        public static List<tasks> fetchByProcess(decimal id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.tasks.Where(x => x.process_id == id).ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static decimal createTask(tasks tasks) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_TASK_INSERT(tasks.name, tasks.description,
                        tasks.process_id, tasks.father_taks_id,
                        tasks.task_status, tasks.date_start,
                        tasks.date_end, DateTime.Now,
                        tasks.creator_user_id, tasks.assing_id);
                    var result = conn.tasks.Where(x => x.name == tasks.name
                    && x.description == tasks.description
                    && x.creator_user_id == tasks.creator_user_id).FirstOrDefault();

                    if (result != null) {
                        log_task logTask = new log_task();
                        logTask.task_id = result.id;
                        logTask.task_status_code = tasks.task_status;
                        conn.log_task.Add(logTask);
                        //conn.SaveChanges();

                        return result.id;
                    } else {
                        return -1;
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static void refuseTask(decimal id, String message, decimal userId) {
            using (var conn = new db_entities()) {
                try {
                    var task = conn.tasks.Where(x => x.id == id).FirstOrDefault();

                    if (task != null) {
                        task.task_status = "3";
                    }

                    alerts alert = new alerts();
                    alert.message = message;
                    alert.task_id = id;
                    alert.created_at = DateTime.Now;
                    alert.state = 0;
                    conn.alerts.Add(alert);

                    conn.SaveChanges();

                    conn.SP_LOG_TASK(id, userId, DateTime.Now, "3");

                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static void acceptTask(decimal id, decimal userId) {
            using (var conn = new db_entities()) {
                try {
                    var task = conn.tasks.Where(x => x.id == id).FirstOrDefault();

                    if (task != null) {
                        task.task_status = "4";
                    }
                    conn.SaveChanges();

                    conn.SP_LOG_TASK(id, userId, DateTime.Now, "4");

                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
