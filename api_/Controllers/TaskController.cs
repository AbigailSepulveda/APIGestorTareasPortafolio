﻿using api_.Domain;
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

        [Route("getAssignTasksByUser")]
        [HttpGet]
        public HttpResponseMessage getAssignTasksByUser(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskDomain.getAssignTasksByUser(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("getRejectionTasksByCreator")]
        [HttpGet]
        public HttpResponseMessage getRejectionTasksByCreator(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskDomain.getRejectionTasksByCreator(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("assignTask")]
        [HttpPost]
        public HttpResponseMessage assignTask(Task task) {
            try {
                TaskDomain.assignTask(task.id, task.assingId);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("getTasksByProcessId")]
        [HttpGet]
        public HttpResponseMessage getTasksByProcessId(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskDomain.getTasksByProcessId(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("getTasksByUserId")]
        [HttpGet]
        public HttpResponseMessage getTasksByUserId(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskDomain.getTasksByUserId(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("getByTaskId")]
        [HttpGet]
        public HttpResponseMessage getByTaskId(decimal id) {
            try {
                return response(HttpStatusCode.OK, true, "ready", TaskDomain.fetchById(id));
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("getAllByUnit")]
        [HttpGet]
        public HttpResponseMessage getAllByUnit(string unit_id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.fetchByUnit(decimal.Parse(unit_id)));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getReportAlerts")]
        [HttpGet]
        public HttpResponseMessage getReportAlerts(decimal id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getReportAlerts(id));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getReportTask")]
        [HttpGet]
        public HttpResponseMessage getReportTask(decimal id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getReportTask(id));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getReportProcess")]
        [HttpGet]
        public HttpResponseMessage getReportProcess(decimal id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getReportProcess(id));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getReportUnit")]
        [HttpGet]
        public HttpResponseMessage getReportUnit(decimal id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getReportUnit(id));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getTaskRed")]
        [HttpGet]
        public HttpResponseMessage getTaskRed(string unit_id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getTaskRed(decimal.Parse(unit_id)));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getTaskYellow")]
        [HttpGet]
        public HttpResponseMessage getTaskYellow(string unit_id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getTaskYellow(decimal.Parse(unit_id)));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
            }
        }

        [Route("getTaskGreen")]
        [HttpGet]
        public HttpResponseMessage getTaskGreen(string unit_id) {
            if (checkToken(Request)) {
                try {
                    return response(HttpStatusCode.OK, true, "ready", TaskDomain.getTaskGreen(decimal.Parse(unit_id)));
                } catch (Exception e) {
                    return response(HttpStatusCode.InternalServerError, false, e);
                }
            } else {
                return response(HttpStatusCode.Unauthorized, false, "invalid token");
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

        [Route("refuseTask")]
        [HttpPost]
        public HttpResponseMessage refuseTask(Task task) {
            try {
                TaskDomain.refuseTask(task.id, task.description, task.creatorUserId);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("acceptTask")]
        [HttpPost]
        public HttpResponseMessage acceptTask(Task task) {
            try {
                TaskDomain.acceptTask(task.id, task.creatorUserId);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }

        [Route("editTask")]
        [HttpPost]
        public HttpResponseMessage editTask(Task task) {
            try {
                TaskDomain.editTask(task.id, task.taskStatusId, task.assingId);
                return response(HttpStatusCode.OK, true, "ready");
            } catch (Exception e) {
                return response(HttpStatusCode.OK, false, e);
            }
        }
    }
}
