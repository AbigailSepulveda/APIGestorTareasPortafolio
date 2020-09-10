﻿using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class ModuleDAL {

        public ModuleDAL() {
            // default
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(String name) {
            using (var conn = new db()) {
                try {
                    modules entity = new modules();
                    entity.name = name;
                    entity.created_at = new DateTime();
                    entity.state = 1;
                    conn.modules.Add(entity);
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(decimal id, String name, int state) {
            using (var conn = new db()) {
                try {
                    var entity = conn.modules.Where(x => x.id == id).FirstOrDefault();
                    entity.name = name;
                    entity.state = state;
                    entity.updated_at = new DateTime();
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<modules> fetchAll() {
            using (var conn = new db()) {
                try {
                    return conn.modules.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
