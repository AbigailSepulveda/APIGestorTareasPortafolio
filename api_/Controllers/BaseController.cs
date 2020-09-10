using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    public abstract class BaseController : ApiController {
        /**
         * Método para responser con un objeto dinamico y estructura estandar        
         */
        protected HttpResponseMessage response<X>(HttpStatusCode status, bool success,
            string message, X data) {
            var result = new {
                success,
                message,
                data
            };
            return Request.CreateResponse(status, result);
        }

        /**
         * Método para responser en caso de no enviar un objeto en data y solo la estructura estandar
         */
        protected HttpResponseMessage response(HttpStatusCode status, bool success,
            string message) {
            var result = new {
                success,
                message,
                data = new Object()
            };
            return Request.CreateResponse(status, result);
        }
    }
}