using api_.Domain;
using api_.Models;
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
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", UnitDomain.fetchAll());
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("insert")]
        [HttpPost]
        public HttpResponseMessage insert(Unit unit) {
            if (checkToken(Request)) {
                try {
                    UnitDomain.insert(unit.name, unit.boss_id);
                    return response(HttpStatusCode.OK, true, "ready");
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(Unit unit) {
            if (checkToken(Request)) {
                try {
                    UnitDomain.update(unit.id, unit.name, unit.state, unit.boss_id);
                    return response(HttpStatusCode.OK, true, "ready");
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }
    }
}
