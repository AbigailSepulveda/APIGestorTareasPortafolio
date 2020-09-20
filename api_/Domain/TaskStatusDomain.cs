using api_.DAL;
using api_.Exceptions;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class TaskStatusDomain {

        public TaskStatusDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<TaskStatus> fetchAll() {
            try {
                return TaskStatusDAL.fetchAll().Select(x => new TaskStatus {
                    id = long.Parse(x.id + ""),
                    code = x.code,
                    name = x.name,
                    state = int.Parse(x.state + "")
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(String code, String name) {
            try {
                if (TaskStatusDAL.exists(code, name)) {
                    throw new ExistsException();
                } else {
                    TaskStatusDAL.insert(code, name);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(long id, String code, String name, int state) {
            try {
                TaskStatusDAL.update(id, code, name, state);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
