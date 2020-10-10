using api_.Domain;
using api_.Request;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Rol")]
    public class RolController : BaseController {

        public RolController() {
            // default
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", RolDomain.fetchAll());
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert(RolInsertRequest request) {
            if (checkToken(Request)) {
                try {
                    RolDomain.insert(request.name, request.modules);
                    return response(HttpStatusCode.OK, true, "ready");
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(RolUpdateRequest request) {
            if (checkToken(Request)) {
                try {
                    RolDomain.update(request.id, request.name, request.state, request.modules);
                    return response(HttpStatusCode.OK, true, "ready");
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }
    }
}
