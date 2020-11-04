using api_.DAL;
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
        public static List<Process> fetchAllByUser(decimal id) {
            try {
                return ProcessDAL.fetchAllByUser(id).Select(x => new Process {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
