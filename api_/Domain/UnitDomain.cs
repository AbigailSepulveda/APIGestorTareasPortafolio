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
                    boss_id = x.boss == null ? null : x.boss,
                    boss = x.boss == null ? null : UserDAL.fetchAll().Where(y => y.id == x.boss).Select(z => new User() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                    }).FirstOrDefault(),
                    enterprise = x.enterprise_id == null ? null : EnterpriseDAL.fetchAll().Where(y => y.id == x.enterprise_id).Select(z => new Enterprise() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                    }).FirstOrDefault(),
                    enterprise_id = long.Parse(x.enterprise_id + "")
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(Unit unit) {
            try {
                if (UnitDAL.exists(unit.name)) {
                    throw new ExistsException();
                } else {
                    UnitDAL.insert(unit.name, unit.boss, unit.enterprise_id);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(Unit unit) {
            try {
                UnitDAL.update(unit.id, unit.name, unit.state, unit.boss, unit.enterprise_id);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
