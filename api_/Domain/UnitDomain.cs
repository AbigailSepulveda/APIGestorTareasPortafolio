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
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    state = int.Parse(x.state + ""),
                    boss_id = long.Parse(x.boss + ""),
                    boss = UserDAL.fetchAll().Where(y => y.id == x.boss).Select(z => new User() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                    }).FirstOrDefault()
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(String name, decimal boss) {
            try {
                if (UnitDAL.exists(name)) {
                    throw new ExistsException();
                } else {
                    UnitDAL.insert(name, boss);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(decimal id, String name, decimal state, decimal boss) {
            try {
                UnitDAL.update(id, name, state, boss);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
