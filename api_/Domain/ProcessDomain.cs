using api_.DAL;
using api_.DB;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class ProcessDomain {

        public ProcessDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Process> fetchAllByUnit(decimal id) {
            try {
                List<Process> list = new List<Process>();
                var mProcess = ProcessDAL.fetchAllByUnit(id).ToList();

                foreach (process proceso in mProcess) {
                    var tasks = TaskDAL.fetchByProcess(proceso.id).Count();
                    Process model = new Process();
                    model.id = long.Parse(proceso.id + "");
                    model.name = proceso.name;
                    model.description = proceso.description;
                    model.n_tasks = tasks;
                    list.Add(model);
                }

                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static void createProcess(String name, String description, decimal userId) {
            try {
                ProcessDAL.insert(name, description, DateTime.Now, userId);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
