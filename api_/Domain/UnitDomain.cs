using api_.DAL;
using api_.Exceptions;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class UnitDomain {

        public UnitDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Unit> fetchAll() {
            try {
                return UnitDAL.fetchAll().Select(x => new Unit {
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
                if (UnitDAL.exists(name)) {
                    throw new ExistsException();
                } else {
                    UnitDAL.insert(name);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(decimal id, String name, int state) {
            try {
                UnitDAL.update(id, name, state);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
