using api_.DAL;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class TaskDomain {

        public TaskDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Task> fetchAllByUser(decimal id) {
            try {
                return TaskDAL.fetchAllByUser(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
