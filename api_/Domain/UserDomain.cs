using api_.DAL;
using api_.DB;
using api_.Exceptions;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class UserDomain {

        public UserDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<User> fetchAll() {
            try {
                return UserDAL.fetchAll().Select(x => new User {
                    id = x.id,
                    name = x.name,
                    email = x.email,
                    password = x.password,
                    rol_id = x.rol_id,
                    unit_id = x.unit_id,
                    state = x.state,
                    token_session = x.token_session,
                    enterprise_id = x.enterprise_id
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(User user) {
            try {

                if (UserDAL.exists(user.email)) {
                    throw new ExistsException();
                } else {
                    users dalUser = new users();
                    dalUser.id = user.id;
                    dalUser.name = user.name;
                    dalUser.email = user.email;
                    dalUser.password = user.password;
                    dalUser.rol_id = user.rol_id;
                    dalUser.unit_id = user.unit_id;
                    dalUser.token_session = user.token_session;
                    dalUser.enterprise_id = user.enterprise_id;
                    UserDAL.insert(dalUser);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(User user) {
            try {
                users dalUser = new users();
                dalUser.id = user.id;
                dalUser.name = user.name;
                dalUser.email = user.email;
                dalUser.password = user.password;
                dalUser.rol_id = user.rol_id;
                dalUser.unit_id = user.unit_id;
                dalUser.token_session = user.token_session;
                dalUser.enterprise_id = user.enterprise_id;
                UserDAL.update(dalUser);
            } catch (Exception e) {
                throw e;
            }
        }

        public static UserLogin signIn(String email, String password) {
            try {
                String token = randomString();
                var x = UserDAL.signIn(email, password, token);
                UserLogin user = new UserLogin();
                user.id = x.id;
                user.name = x.name;
                user.email = x.email;
                user.rol = new Rol() { id = x.roles.id, name = x.roles.name };
                user.unit = new Unit() { id = x.units.id, name = x.units.name };
                user.state = x.state;
                user.token_session = x.token_session;
                user.enterprise = new Enterprise() { id = x.enterprises.id, name = x.enterprises.name };
                return user;
            } catch (Exception e) {
                throw e;
            }
        }

        private static Random random = new Random();

        private static string randomString() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
