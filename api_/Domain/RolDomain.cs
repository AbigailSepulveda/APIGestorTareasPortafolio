using api_.DAL;
using api_.DB;
using api_.Exceptions;
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
                List<Rol> rolesDomain = new List<Rol>();
                var rolesList = RolDAL.fetchAll();

                foreach (roles item in rolesList) {
                    Rol rol = new Rol();
                    rol.id = long.Parse(item.id + "");
                    rol.name = item.name;
                    rol.state = int.Parse(item.state + "");
                    List<Module> modulesDomain = new List<Module>();

                    var modules = RolModuleDAL.fetchAll().Where(x => x.rol_id == item.id).ToList();
                    foreach (roles_modules rm in modules) {
                        var md = ModuleDAL.fetchAll().Where(x => x.id == rm.module_id).Select(y =>
                           new Module() {
                               id = long.Parse(y.id + ""),
                               name = y.name,
                               state = int.Parse(y.state + ""),
                               code = y.code
                           }).FirstOrDefault();
                        modulesDomain.Add(md);
                    }
                    rol.modules = modulesDomain;

                    rolesDomain.Add(rol);
                }
                return rolesDomain;
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(Rol rol) {
            try {
                if (RolDAL.exists(rol.name)) {
                    throw new ExistsException();
                } else {
                    List<modules> modules = rol.modules.Select(x => new modules() {
                        id = x.id,
                        name = x.name
                    }).ToList();

                    RolDAL.insert(rol.name, modules);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(Rol rol) {
            try {
                List<modules> modules = rol.modules.Select(x => new modules() {
                    id = x.id,
                    name = x.name
                }).ToList();
                RolDAL.update(rol.id, rol.name, rol.state, modules);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
