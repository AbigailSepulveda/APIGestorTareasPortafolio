using api_.Domain;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/TypeAlert")]
    public class TypeAlertController : BaseController {
        public TypeAlertController() {
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            try {
                return response(HttpStatusCode.OK, true, "ready", TypeAlertDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert([FromBody] String name) {
            try {
                TypeAlertDomain.insert(name);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody] decimal id, [FromBody] String name, [FromBody]int state) {
            try {
                TypeAlertDomain.update(id, name, state);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }
    }
}
