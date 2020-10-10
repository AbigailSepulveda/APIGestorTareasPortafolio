using api_.DB;
using api_.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class UnitDAL {

        public UnitDAL() {
            // default
        }

        /**
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String name) {
            using (var conn = new db_entities()) {
                try {
                    var result = conn.units.Where(x => x.name.Equals(name)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String name, decimal boss) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_UNIT_INSERT(name, DateTime.Now, 1, boss);
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String name, decimal state, decimal boss) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.units.Where(x => x.id == id).FirstOrDefault();
                    if (entity == null) {
                        throw new NotExistsException();
                    } else {
                        conn.SP_UNIT_UPDATE(id, name, DateTime.Now, state, boss);
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<units> fetchAll() {
            using (var conn = new db_entities()) {
                try {
                    return conn.units.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
