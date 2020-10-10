using api_.Domain;
using api_.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Template")]
    public class TemplateController : BaseController {

        public TemplateController() {
            // default
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            try {
                return response(HttpStatusCode.OK, true, "ready", TemplateDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert(Template template) {
            try {
                TemplateDomain.insert(template);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(Template template) {
            try {
                TemplateDomain.update(template);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
