using api_.DAL;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class ModuleDomain {

        public ModuleDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Module> fetchAll() {
            try {
                return ModuleDAL.fetchAll().Select(x => new Module {
                    id = x.id,
                    name = x.name,
                    state = x.state
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(String name) {
            try {
                ModuleDAL.insert(name);
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(decimal id, String name, int state) {
            try {
                ModuleDAL.update(id, name, state);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
