using api_.Domain;
using api_.Models.request;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Process")]
    public class ProcessController : BaseController {

        public ProcessController() {
            // default
        }

        [Route("getProcessByUnit")]
        [HttpGet]
        public HttpResponseMessage getAll(decimal unit_id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", ProcessDomain.fetchAllByUnit(unit_id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("createProcess")]
        [HttpPost]
        public HttpResponseMessage createProcess(CreateProcessRequest request) {
            try {
                if (checkToken(Request)) {
                    try {
                        ProcessDomain.createProcess(request.name, request.description, request.user_id);
                        return response(HttpStatusCode.OK, true, "ready");
                    } catch (Exception e) {
                        return response(HttpStatusCode.InternalServerError, false, e);
                    }
                } else {
                    return response(HttpStatusCode.Unauthorized, false, "invalid token");
                }
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
