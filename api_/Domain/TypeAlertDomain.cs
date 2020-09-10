using api_.DAL;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class TypeAlertDomain {

        public TypeAlertDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<TypeAlert> fetchAll() {
            try {
                return TypeAlertDAL
                    .fetchAll()
                    .Select(x => new TypeAlert {
                        id = x.id,
                        name = x.name,
                        state = x.state
                    })
                    .ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(String name) {
            try {
                TypeAlertDAL.insert(name);
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(decimal id, String name, int state) {
            try {
                TypeAlertDAL.update(id, name, state);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
