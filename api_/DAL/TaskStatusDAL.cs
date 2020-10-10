using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class TaskStatusDAL {

        public TaskStatusDAL() {
            // default
        }

        /**
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String code, String name) {
            using (var conn = new db_entities()) {
                try {
                    var result = conn.task_statuses.Where(x => x.name.Equals(name) || x.code.Equals(code)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String code, String name) {
            using (var conn = new db_entities()) {
                try {
                    task_statuses entity = new task_statuses();
                    entity.code = code;
                    entity.name = name;
                    entity.created_at = DateTime.Now;
                    entity.state = 1;
                    conn.task_statuses.Add(entity);
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String code, String name, int state) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.task_statuses.Where(x => x.id == id).FirstOrDefault();
                    entity.code = code;
                    entity.name = name;
                    entity.state = state;
                    entity.updated_at = DateTime.Now;
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<task_statuses> fetchAll() {
            using (var conn = new db_entities()) {
                try {
                    return conn.task_statuses.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
