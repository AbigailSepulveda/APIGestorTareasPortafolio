using api_.Domain;
using api_.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    [RoutePrefix("api/ConfigTrafficLight")]
    public class ConfigTrafficLightController : BaseController {
        public ConfigTrafficLightController() {
        }

        [Route("get")]
        [HttpGet]
        public HttpResponseMessage get() {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", ConfigTrafficLightDomain.fetch());
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update(ConfigTrafficLight configTrafficLight) {
            if (checkToken(Request)) {
                try {
                    ConfigTrafficLightDomain.update(configTrafficLight.id, configTrafficLight.green, configTrafficLight.yellow, configTrafficLight.red);
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
