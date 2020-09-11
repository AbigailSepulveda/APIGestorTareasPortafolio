using api_.Domain;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Unit")]
    public class UnitController : BaseController {
        public UnitController() {
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            try {
                return response(HttpStatusCode.OK, true, "ready", UnitDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert([FromBody] String name) {
            try {
                UnitDomain.insert(name);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody] decimal id, [FromBody] String name, [FromBody]int state) {
            try {
                UnitDomain.update(id, name, state);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
