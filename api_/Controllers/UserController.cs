using api_.Domain;
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
            try {
                return response(HttpStatusCode.OK, true, "ready", UserDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert(User user) {
            try {
                UserDomain.insert(user);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(User user) {
            try {
                UserDomain.update(user);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("signIn")]
        [HttpPost]
        public HttpResponseMessage signIn(User user) {
            try {
                return response(HttpStatusCode.OK, true, "ready", UserDomain.signIn(user.email, user.password));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
