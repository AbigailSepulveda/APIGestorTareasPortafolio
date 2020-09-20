using api_.DAL;
using api_.Exceptions;
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
                    id = long.Parse(x.id + ""),
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
        public static void insert(String name) {
            try {
                if (ModuleDAL.exists(name)) {
                    throw new ExistsException();
                } else {
                    ModuleDAL.insert(name);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(long id, String name, int state) {
            try {
                ModuleDAL.update(id, name, state);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
