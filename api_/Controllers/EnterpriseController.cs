using api_.Domain;
using api_.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/Enterprise")]
    public class EnterpriseController : BaseController {
        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage getAll() {
            try {
                return response(HttpStatusCode.OK, true, "ready", EnterpriseDomain.fetchAll());
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert(Enterprise enterprise) {
            try {
                EnterpriseDomain.insert(enterprise.name);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(Enterprise enterprise) {
            try {
                EnterpriseDomain.update(enterprise.id, enterprise.name);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
