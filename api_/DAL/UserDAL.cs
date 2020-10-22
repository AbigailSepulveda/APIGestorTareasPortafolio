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
            using (var conn = new db_entities()) {
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
            using (var conn = new db_entities()) {
                try {
                    conn.SP_USER_INSERT(user.name, user.email, user.password, user.rol_id, user.unit_id,
                        DateTime.Now, 1, user.enterprise_id);
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(users user) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.users.Where(x => x.id == user.id).FirstOrDefault();
                    user.updated_at = new DateTime();
                    if (entity == null) {
                        throw new NotExistsException();
                    } else {
                        if (user.password == null || user.password == "") {
                            conn.SP_USER_UPDATE_WITHOUT_PASSWORD(user.id, user.name, user.email, user.rol_id, user.unit_id,
                                DateTime.Now, user.state, user.enterprise_id);
                        } else {
                            conn.SP_USER_UPDATE_WITH_PASSWORD(user.id, user.name, user.email, user.password, user.rol_id, user.unit_id,
                                DateTime.Now, user.state, user.enterprise_id);
                        }
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para iniciar sesion desde el telefono
         */
        public static users signInMovil(String email, String pass, String token) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.users.Where(x => x.email == email && x.password == pass && x.rol_id == 0).FirstOrDefault();
                    if (entity != null) {
                        entity.token_session = token;
                        conn.SaveChanges();
                        return entity;
                    } else {
                        throw new NotFoundException();
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para iniciar sesion desde la web
         */
        public static users signIn(String email, String pass, String token) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.users.Where(x => x.email == email && x.password == pass).FirstOrDefault();
                    if (entity != null) {
                        entity.token_session = token;
                        conn.SaveChanges();
                        return entity;
                    } else {
                        throw new NotFoundException();
                    }
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para actualizar el registro
         */
        public static bool checkToken(String token) {
            using (var conn = new db_entities()) {
                try {
                    var entity = conn.users.Where(x => x.token_session == token && x.state == 1
                    ).FirstOrDefault();
                    return entity != null;
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static List<users> fetchAll() {
            using (var conn = new db_entities()) {
                try {
                    return conn.users.ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
