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
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    email = x.email,
                    password = x.password,
                    rol = RolDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Rol() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                        state = int.Parse(z.state + "")
                    }).FirstOrDefault(),
                    unit = UnitDAL.fetchAll().Where(y => y.id == x.unit_id).Select(z => new Unit() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                        state = int.Parse(z.state + "")
                    }).FirstOrDefault(),
                    enterprise = EnterpriseDAL.fetchAll().Where(y => y.id == x.enterprise_id).Select(z => new Enterprise() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                    }).FirstOrDefault(),
                    rol_id = long.Parse(x.rol_id + ""),
                    unit_id = long.Parse(x.unit_id + ""),
                    state = int.Parse(x.state + ""),
                    token_session = x.token_session,
                    enterprise_id = long.Parse(x.enterprise_id + "")
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
                    dalUser.password = encodeTo64(user.password);
                    dalUser.rol_id = user.rol_id;
                    dalUser.unit_id = user.unit_id;
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
                if (user.password != null || user.password != "") {
                    dalUser.password = encodeTo64(user.password);
                }
                dalUser.rol_id = user.rol_id;
                dalUser.unit_id = user.unit_id;
                dalUser.enterprise_id = user.enterprise_id;
                UserDAL.update(dalUser);
            } catch (Exception e) {
                throw e;
            }
        }

        public static UserLogin signInMovil(String email, String password) {
            try {
                String token = randomString();
                var x = UserDAL.signIn(email, encodeTo64(password), token);
                UserLogin user = new UserLogin();
                user.id = long.Parse(x.id + "");
                user.name = x.name;
                user.email = x.email;
                user.rol = RolDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Rol() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                    state = int.Parse(z.state + "")
                }).FirstOrDefault();
                user.unit = UnitDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Unit() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                    state = int.Parse(z.state + "")
                }).FirstOrDefault();
                user.enterprise = EnterpriseDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Enterprise() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                }).FirstOrDefault();
                user.state = int.Parse(x.state + "");
                user.token_session = x.token_session;
                return user;
            } catch (Exception e) {
                throw e;
            }
        }

        public static bool checkToken(String token) {
            return UserDAL.checkToken(token);
        }

        private static Random random = new Random();

        private static string randomString() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string encodeTo64(string toEncode) {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
    }
}
