﻿using api_.DAL;
using api_.Exceptions;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class EnterpriseDomain {

        public EnterpriseDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Enterprise> fetchAll() {
            try {
                return EnterpriseDAL.fetchAll().Select(x => new Enterprise {
                    id = int.Parse(x.id + ""),
                    name = x.name,
                    state = int.Parse(x.state+"")
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
                if (EnterpriseDAL.exists(name)) {
                    throw new ExistsException();
                } else {
                    EnterpriseDAL.insert(name);
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
                EnterpriseDAL.update(id, name, state);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
