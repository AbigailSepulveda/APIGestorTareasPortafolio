using api_.DAL;
using api_.DB;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class RolDomain {

        public RolDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Rol> fetchAll() {
            try {
                return RolDAL.fetchAll().Select(x => new Rol {
                    id = x.id,
                    name = x.name,
                    modules = x.roles_modules.Where(z => z.rol_id == x.id).ToList().Select(y => new Module {
                        id = y.modules.id,
                        name = y.modules.name,

                    }).ToList()
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(String name, List<Module> modules) {
            try {
                var now = new DateTime();
                var dalModules = modules.Select(x => new modules() {
                    name = x.name,
                    state = x.state,
                    created_at = now
                }).ToList();

                RolDAL.insert(name, dalModules);
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(decimal id, String name, List<Module> modules) {
            try {
                var now = new DateTime();
                var dalModules = modules.Select(x => new modules() {
                    name = x.name,
                    state = x.state,
                    created_at = now,
                    updated_at = now
                }).ToList();

                RolDAL.update(id, name, dalModules);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
