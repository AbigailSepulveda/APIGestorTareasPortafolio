using api_.Domain;
using api_.Models;
using System;
using System.Collections.Generic;
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
            try {
                return response(HttpStatusCode.OK, true, "ready", RolDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert([FromBody] String name, [FromBody] List<Module> modules) {
            try {
                RolDomain.insert(name, modules);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody] decimal id, [FromBody] String name, [FromBody] List<Module> modules) {
            try {
                RolDomain.update(id, name, modules);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }
    }
}
