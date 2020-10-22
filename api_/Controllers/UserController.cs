using api_.Domain;
using api_.Exceptions;
using api_.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/User")]
    public class UserController : BaseController {
        public UserController() {
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", UserDomain.fetchAll());
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert(User user) {
            if (checkToken(Request)) {
                try {
                    UserDomain.insert(user);
                    return response(HttpStatusCode.OK, true, "ready");
                } catch (Exception e) {
                    return response(HttpStatusCode.OK, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(User user) {
            if (checkToken(Request)) {
                try {
                    UserDomain.update(user);
                    return response(HttpStatusCode.OK, true, "ready");
                } catch (Exception e) {
                    if(e is NotExistsException) {
                        return response(HttpStatusCode.NotFound, false, e);
                    } else {
                        return response(HttpStatusCode.InternalServerError, false, e);
                    }
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("signInMovil")]
        [HttpPost]
        public HttpResponseMessage signInMovil(User user) {
            try {
                return response(HttpStatusCode.OK, true, "ready", UserDomain.signInMovil(user.email, user.password));
            } catch (Exception e) {
                if (e is NotFoundException) {
                    return response(HttpStatusCode.Unauthorized, false, e);
                } else {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            }
        }

        [Route("signIn")]
        [HttpPost]
        public HttpResponseMessage signIn(User user) {
            try {
                return response(HttpStatusCode.OK, true, "ready", UserDomain.signIn(user.email, user.password));
            } catch (Exception e) {
                if (e is NotFoundException) {
                    return response(HttpStatusCode.Unauthorized, false, e);
                } else {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            }
        }
    }
}
