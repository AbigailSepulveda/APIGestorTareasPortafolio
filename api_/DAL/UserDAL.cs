using api_.DB;
using api_.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class UserDAL {

        public UserDAL() {
            // default
        }

        /**
         * Método para validar si existe el registro
         * @return true si existe
         */
        public static bool exists(String email) {
            using (var conn = new db()) {
                try {
                    var result = conn.users.Where(x => x.email.Equals(email)).FirstOrDefault();
                    return result != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para crear nuevo registro
         */
        public static void insert(users user) {
            using (var conn = new db()) {
                try {
                    user.created_at = new DateTime();
                    user.state = 1;
                    conn.users.Add(user);
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(users user) {
            using (var conn = new db()) {
                try {
                    var entity = conn.units.Where(x => x.id == user.id).FirstOrDefault();
                    user.id = entity.id;
                    user.updated_at = new DateTime();
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static users signIn(String email, String pass, String token) {
            using (var conn = new db()) {
                try {
                    var entity = conn.users.Where(x => x.email == email && x.password == pass).FirstOrDefault();
                    if (entity != null) {
                        entity.token_session = token;
                        conn.SaveChanges();
                        return entity;
                    } else {
                        throw new AuthenticationException();
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<users> fetchAll() {
            using (var conn = new db()) {
                try {
                    return conn.users.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
