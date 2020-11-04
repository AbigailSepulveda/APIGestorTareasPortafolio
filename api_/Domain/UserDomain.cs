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

        public static List<User> fetchByUnit(decimal unitId) {
            try {
                return UserDAL.fetchAll().Where(x => x.unit_id == unitId).Select(x => new User {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    email = x.email,
                    rol = x.rol_id == null ? null : RolDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Rol() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                        state = int.Parse(z.state + "")
                    }).FirstOrDefault(),
                    unit = x.unit_id == null ? null : UnitDAL.fetchAll().Where(y => y.id == x.unit_id).Select(z => new Unit() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                        state = int.Parse(z.state + "")
                    }).FirstOrDefault(),
                    rol_id = long.Parse(x.rol_id + ""),
                    unit_id = long.Parse(x.unit_id + ""),
                    state = int.Parse(x.state + "")
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
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
                    rol = x.rol_id == null ? null : RolDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Rol() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                        state = int.Parse(z.state + "")
                    }).FirstOrDefault(),
                    unit = x.unit_id == null ? null : UnitDAL.fetchAll().Where(y => y.id == x.unit_id).Select(z => new Unit() {
                        id = long.Parse(z.id + ""),
                        name = z.name,
                        state = int.Parse(z.state + "")
                    }).FirstOrDefault(),
                    rol_id = long.Parse(x.rol_id + ""),
                    unit_id = long.Parse(x.unit_id + ""),
                    state = int.Parse(x.state + ""),
                    token_session = x.token_session
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
                dalUser.state = user.state;
                if (user.password != null && user.password != "") {
                    dalUser.password = encodeTo64(user.password);
                }
                dalUser.rol_id = user.rol_id;
                dalUser.unit_id = user.unit_id;
                UserDAL.update(dalUser);
            } catch (Exception e) {
                throw e;
            }
        }

        public static UserLogin signInMovil(String email, String password) {
            try {
                String token = randomString();
                var x = UserDAL.signInMovil(email, encodeTo64(password), token);
                UserLogin user = new UserLogin();
                user.id = long.Parse(x.id + "");
                user.name = x.name;
                user.email = x.email;
                user.rol = x.rol_id == null ? null : RolDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Rol() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                    state = int.Parse(z.state + "")
                }).FirstOrDefault();
                user.unit = x.unit_id == null ? null : UnitDAL.fetchAll().Where(y => y.id == x.unit_id).Select(z => new Unit() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                    state = int.Parse(z.state + "")
                }).FirstOrDefault();
                user.state = int.Parse(x.state + "");
                user.token_session = x.token_session;
                return user;
            } catch (Exception e) {
                throw e;
            }
        }

        public static UserLogin signIn(String email, String password) {
            try {
                String token = randomString();
                var x = UserDAL.signIn(email, encodeTo64(password), token);
                UserLogin user = new UserLogin();
                user.id = long.Parse(x.id + "");
                user.name = x.name;
                user.email = x.email;
                user.rol = x.rol_id == null ? null : RolDAL.fetchAll().Where(y => y.id == x.rol_id).Select(z => new Rol() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                    state = int.Parse(z.state + "")
                }).FirstOrDefault();
                user.unit = x.unit_id == null ? null : UnitDAL.fetchAll().Where(y => y.id == x.unit_id).Select(z => new Unit() {
                    id = long.Parse(z.id + ""),
                    name = z.name,
                    state = int.Parse(z.state + "")
                }).FirstOrDefault();
                user.state = int.Parse(x.state + "");
                user.token_session = x.token_session;


                List<Module> modulesDomain = new List<Module>();

                var modules = RolModuleDAL.fetchAll().Where(rm => rm.rol_id == user.rol.id).ToList();
                foreach (roles_modules rm in modules) {
                    var md = ModuleDAL.fetchAll().Where(mo => mo.id == rm.module_id).Select(y =>
                       new Module() {
                           id = long.Parse(y.id + ""),
                           name = y.name,
                           state = int.Parse(y.state + ""),
                           code = y.code
                       }).FirstOrDefault();
                    modulesDomain.Add(md);
                }
                user.rol.modules = modulesDomain;


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
