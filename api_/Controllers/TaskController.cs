using api_.Domain;
using api_.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Task")]
    public class TaskController : BaseController {

        public TaskController() {
            // default
        }

        [Route("getTasksByUser")]
        [HttpGet]
        public HttpResponseMessage getAll(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskDomain.fetchAllByUser(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("createTask")]
        [HttpPost]
        public HttpResponseMessage createTask(Task task) {
            try {
                TaskDomain.createTask(task);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
