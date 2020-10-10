using api_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_.Controllers {
    public abstract class BaseController : ApiController {

        protected bool checkToken(HttpRequestMessage request) {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("Authorization")) {
                string token = headers.GetValues("Authorization").First();
                return UserDomain.checkToken(token);
            } else {
                return false;
            }
        }

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

        protected HttpResponseMessage response(HttpStatusCode status, bool success,
            string message) {
            Object pData = null;
            var result = new {
                success,
                message,
                data = pData
            };
            return Request.CreateResponse(status, result);
        }

        /**
         * Método para responser en caso de no enviar un objeto en data y solo la estructura estandar
         */
        protected HttpResponseMessage response(HttpStatusCode status, bool success,
            Exception exception) {
            Object pData = null;
            var result = new {
                success,
                message = "Error: " + exception.Message.ToString(),
                data = pData
            };
            return Request.CreateResponse(status, result);
        }
    }
}