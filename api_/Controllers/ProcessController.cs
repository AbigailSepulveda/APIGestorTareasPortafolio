using api_.Domain;
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

        [Route("getProcessByUser")]
        [HttpGet]
        public HttpResponseMessage getAll(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", ProcessDomain.fetchAllByUser(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
