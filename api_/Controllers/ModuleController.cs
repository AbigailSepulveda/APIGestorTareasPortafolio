using api_.Domain;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Module")]
    public class ModuleController : BaseController {

        public ModuleController() {
            // default
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            try {
                return response(HttpStatusCode.OK, true, "ready", ModuleDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert([FromBody] String name) {
            try {
                ModuleDomain.insert(name);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody] decimal id, [FromBody] String name, int state) {
            try {
                ModuleDomain.update(id, name, state);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }
    }
}
