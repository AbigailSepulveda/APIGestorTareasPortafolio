using api_.Domain;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/TaskStatus")]
    public class TaskStatusController : BaseController {
        public TaskStatusController() {
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskStatusDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert([FromBody] String code, [FromBody] String name) {
            try {
                TaskStatusDomain.insert(code, name);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody] decimal id, [FromBody] String code, [FromBody] String name, [FromBody]int state) {
            try {
                TaskStatusDomain.update(id, code, name, state);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, "Error: " + e.Message.ToString());
            }
        }
    }
}
