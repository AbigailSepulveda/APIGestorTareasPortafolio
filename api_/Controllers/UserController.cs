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
        public HttpResponseMessage insert([FromBody] User user) {
            try {
                UserDomain.insert(user);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody]User user) {
            try {
                UserDomain.update(user);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("signIn")]
        [HttpPost]
        public HttpResponseMessage signIn([FromBody]String email, [FromBody]String password) {
            try {
                return response(HttpStatusCode.OK, true, "ready", UserDomain.signIn(email, password));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
