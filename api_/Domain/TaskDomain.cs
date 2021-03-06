﻿using api_.DAL;
using api_.DB;
using api_.Exceptions;
using api_.Models;
using api_.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class TaskDomain {

        public TaskDomain() {
            // default
        }

        public static Task fetchById(decimal id) {
            try {
                Task task = null;
                var result = TaskDAL.fetchById(id);

                if (result != null) {
                    task = new Task();
                    task.id = long.Parse(result.id + "");
                    task.name = result.name;
                    if (result.assing_id != null) {
                        task.assingId = long.Parse(result.assing_id + "");
                    } else {
                        task.assingId = -1;
                    }
                    task.description = result.description;
                    task.dateStart = result.date_start;
                    if (task.dateStart != null) {
                        task.sDateStart = ((DateTime)task.dateStart).ToString("dd/MM/yyyy").Replace("-", "/");
                    }
                    task.dateEnd = result.date_end;
                    if (task.dateEnd != null) {
                        task.sDateEnd = ((DateTime)task.dateEnd).ToString("dd/MM/yyyy").Replace("-", "/");
                    }
                    task.creatorUserId = long.Parse(result.creator_user_id + "");
                    task.name = result.name;
                    task.taskStatusId = result.task_status;
                    task.documents = DocumentDAL.fetchAllByTaskId(long.Parse(result.id + "")).Select(x => new Document() {
                        id = long.Parse(x.id + ""),
                        name = x.name,
                        path = x.path,
                        url = x.url,
                        task_id = long.Parse(x.task_id + "")
                    }).ToList();
                }

                return task;
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Task> fetchAllByUser(decimal id) {
            try {

                return TaskDAL.fetchAllByUser(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> getAssignTasksByUser(decimal id) {
            try {
                List<Task> list = new List<Task>();
                var dTasks = TaskDAL.getAssignTasksByUser(id).ToList();

                foreach (tasks item in dTasks) {
                    Task task = new Task();
                    task.id = long.Parse(item.id + "");
                    task.name = item.name;
                    task.description = item.description;
                    task.dateEnd = item.date_end;
                    task.sDateEnd = ((DateTime)item.date_end).ToString("dd/MM/yyyy").Replace("-", "/");

                    if (item.process_id != null) {
                        var process = ProcessDAL.getById(Decimal.Parse(item.process_id + ""));
                        Process dProcess = new Process();
                        dProcess.name = process.name;
                        dProcess.description = process.description;
                        dProcess.id = long.Parse(process.id + "");
                        task.process = dProcess;
                    }

                    var listFiles = DocumentDAL.fetchAllByTaskId(long.Parse(item.id + "")).Select(x => new Document() {
                        id = long.Parse(x.id + ""),
                        name = x.name,
                        url = x.url,
                        path = x.path,
                        task_id = x.task_id
                    }).ToList();

                    task.documents = listFiles;
                    list.Add(task);
                }


                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Alert> getRejectionTasksByCreator(decimal id) {
            try {
                List<Alert> list = new List<Alert>();
                var dTasks = TaskDAL.getCreationTasksByUser(id).ToList();

                foreach (tasks item in dTasks) {
                    var dAlert = AlertDAL.fetchByTaskId(long.Parse(item.id + ""));
                    if (dAlert != null) {
                        Task task = new Task();
                        task.id = long.Parse(item.id + "");
                        task.name = item.name;
                        task.description = item.description;
                        task.dateEnd = item.date_end;
                        task.sDateEnd = ((DateTime)item.date_end).ToString("dd/MM/yyyy").Replace("-", "/");

                        if (item.process_id != null) {
                            var process = ProcessDAL.getById(Decimal.Parse(item.process_id + ""));
                            Process dProcess = new Process();
                            dProcess.name = process.name;
                            dProcess.description = process.description;
                            dProcess.id = long.Parse(process.id + "");
                            task.process = dProcess;
                        }

                        var user = UserDAL.fetchAll().Where(x => x.id == item.assing_id).FirstOrDefault();

                        User mUser = new User();
                        mUser.id = long.Parse(user.id + "");
                        mUser.name = user.name;

                        task.creatorUser = mUser;

                        Alert alert = new Alert();

                        alert.id = dAlert.id;
                        alert.message = dAlert.message;
                        alert.state = int.Parse(dAlert.state + "");
                        alert.task = task;

                        list.Add(alert);
                    }
                }


                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> getTasksByProcessId(decimal id) {
            try {
                List<Task> list = new List<Task>();
                var dTasks = TaskDAL.getTasksByProcessId(id).ToList();

                foreach (tasks item in dTasks) {
                    Task task = new Task();
                    task.id = long.Parse(item.id + "");
                    task.name = item.name;
                    task.description = item.description;
                    task.dateEnd = item.date_end;
                    task.sDateEnd = ((DateTime)item.date_end).ToString("dd/MM/yyyy").Replace("-", "/");

                    if (item.process_id != null) {
                        var process = ProcessDAL.getById(Decimal.Parse(item.process_id + ""));
                        Process dProcess = new Process();
                        dProcess.name = process.name;
                        dProcess.description = process.description;
                        dProcess.id = long.Parse(process.id + "");
                        task.process = dProcess;
                    }

                    var listFiles = DocumentDAL.fetchAllByTaskId(long.Parse(item.id + "")).Select(x => new Document() {
                        id = long.Parse(x.id + ""),
                        name = x.name,
                        url = x.url,
                        path = x.path,
                        task_id = x.task_id
                    }).ToList();

                    task.documents = listFiles;

                    task.alert = 0;

                    list.Add(task);
                }


                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> getTasksByUserId(decimal id) {
            try {
                List<Task> list = new List<Task>();
                var dTasks = TaskDAL.getTasksByUser(id);

                foreach (tasks item in dTasks) {
                    Task task = new Task();
                    task.id = long.Parse(item.id + "");
                    task.name = item.name;
                    task.description = item.description;
                    task.dateEnd = item.date_end;
                    task.sDateEnd = ((DateTime)item.date_end).ToString("dd/MM/yyyy").Replace("-", "/");

                    if (item.process_id != null) {
                        var process = ProcessDAL.getById(Decimal.Parse(item.process_id + ""));
                        Process dProcess = new Process();
                        dProcess.name = process.name;
                        dProcess.description = process.description;
                        dProcess.id = long.Parse(process.id + "");
                        task.process = dProcess;
                    }

                    var listFiles = DocumentDAL.fetchAllByTaskId(long.Parse(item.id + "")).Select(x => new Document() {
                        id = long.Parse(x.id + ""),
                        name = x.name,
                        url = x.url,
                        path = x.path,
                        task_id = x.task_id
                    }).ToList();

                    task.documents = listFiles;

                    var alert = ConfigTrafficLightDAL.fetch();

                    var end = (DateTime)item.date_end;
                    var now = DateTime.Now;
                    var date = -(Math.Round((now - end).TotalDays));

                    if (date <= double.Parse(alert.red + "")) {
                        task.alert = 1;
                    } else if (date <= double.Parse(alert.yellow + "")) {
                        task.alert = 2;
                    } else if (date > double.Parse(alert.green + "")) {
                        task.alert = 3;
                    }

                    list.Add(task);
                }


                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> fetchByUnit(decimal id) {
            try {

                return TaskDAL.fetchAllByUnit(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        public static ListReportAlerts getReportAlerts(decimal id) {
            try {

                var list = TaskDAL.fetchAllByUser(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();

                ListReportAlerts response = new ListReportAlerts();

                var alert = ConfigTrafficLightDAL.fetch();

                int red = 0;
                int yellow = 0;
                int green = 0;

                foreach (Task task in list) {
                    var end = (DateTime)task.dateEnd;
                    var now = DateTime.Now;
                    var date = -(Math.Round((now - end).TotalDays));

                    if (date <= double.Parse(alert.red + "") && task.taskStatusId != "2" && task.taskStatusId != "3") {
                        red++;
                    } else
                    if (date <= double.Parse(alert.yellow + "")
                        && task.taskStatusId != "2" && task.taskStatusId != "3") {
                        yellow++;
                    } else if (date > double.Parse(alert.green + "")
                        && task.taskStatusId != "2" && task.taskStatusId != "3") {
                        green++;
                    }
                }

                response.red = red;
                response.yellow = yellow;
                response.green = green;
                return response;
            } catch (Exception e) {
                throw e;
            }
        }

        public static ListReportTask getReportTask(decimal id) {
            try {

                var list = TaskDAL.fetchAllByUser(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();

                ListReportTask response = new ListReportTask();

                int ready = 0;
                int working = 0;
                int pending = 0;

                foreach (Task task in list) {
                    if (task.taskStatusId == "0") {
                        pending++;
                    } else if (task.taskStatusId == "2") {
                        ready++;
                    } else if (task.taskStatusId == "4") {
                        working++;
                    }
                }

                response.tasks = list.Count();
                response.done = ready;
                response.working = working;
                response.pending = pending;
                return response;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<ListReportProcess> getReportProcess(decimal id) {
            try {
                List<ListReportProcess> processList = new List<ListReportProcess>();

                var dProcess = ProcessDAL.fetchAllByUnit(id);

                foreach (process p in dProcess) {
                    ListReportProcess response = new ListReportProcess();
                    response.processId = int.Parse(p.id + "");
                    response.processName = p.name;

                    var list = TaskDAL.fetchByProcess(p.id).Select(x => new Task {
                        id = long.Parse(x.id + ""),
                        name = x.name,
                        taskStatusId = x.task_status,
                    }).ToList();

                    response.taskList = list;

                    int ready = 0;
                    int working = 0;
                    int pending = 0;

                    foreach (Task task in list) {
                        if (task.taskStatusId == "0") {
                            pending++;
                        } else if (task.taskStatusId == "2") {
                            ready++;
                        } else if (task.taskStatusId == "4") {
                            working++;
                        }
                    }

                    response.tasks = list.Count();
                    response.done = ready;
                    response.working = working;
                    response.pending = pending;

                    processList.Add(response);
                }

                return processList;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<ListReportUnit> getReportUnit(decimal id) {
            try {
                List<ListReportUnit> processList = new List<ListReportUnit>();

                var dUnit = UnitDAL.fetchAll().Where(x => x.id == id).FirstOrDefault();

                var dUnits = UnitDAL.fetchAll().Where(x => x.enterprise_id == dUnit.enterprise_id).ToList();

                foreach (units u in dUnits) {
                    ListReportUnit response = new ListReportUnit();
                    response.unitId = int.Parse(u.id + "");
                    response.unitName = u.name;

                    var list = TaskDAL.fetchAllByUnit(u.id).Select(x => new Task {
                        id = long.Parse(x.id + ""),
                        name = x.name,
                        taskStatusId = x.task_status,
                    }).ToList();

                    int ready = 0;
                    int working = 0;
                    int pending = 0;

                    foreach (Task task in list) {
                        if (task.taskStatusId == "0") {
                            pending++;
                        } else if (task.taskStatusId == "2") {
                            ready++;
                        } else if (task.taskStatusId == "4") {
                            working++;
                        }
                    }

                    response.done = ready;
                    response.working = working;
                    response.pending = pending;

                    processList.Add(response);
                }
                return processList;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> getTaskRed(decimal id) {
            try {

                var list = TaskDAL.fetchAllByUnit(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();

                List<Task> newList = new List<Task>();
                var alert = ConfigTrafficLightDAL.fetch();
                foreach (Task task in list) {
                    var end = (DateTime)task.dateEnd;
                    var now = DateTime.Now;
                    var date = -(Math.Round((now - end).TotalDays));

                    if (date <= double.Parse(alert.red + "") && task.taskStatusId != "2" && task.taskStatusId != "3") {
                        User dUser = new User();
                        if (task.assingId != 0) {
                            var user = UserDAL.fetchAll().Where(x => x.id == task.assingId).FirstOrDefault();
                            if (user != null) {
                                dUser.id = long.Parse(user.id + "");
                                dUser.name = user.name;
                            } else {
                                dUser.name = "Sin Asignar";
                            }
                        } else {
                            dUser.name = "Sin Asignar";
                        }
                        task.creatorUser = dUser;

                        if (task.dateEnd != null) {
                            task.sDateEnd = ((DateTime)task.dateEnd).ToString("dd/MM/yyyy").Replace("-", "/");
                        }


                        newList.Add(task);
                    }
                }
                return newList;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> getTaskYellow(decimal id) {
            try {

                var list = TaskDAL.fetchAllByUnit(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();

                List<Task> newList = new List<Task>();
                var alert = ConfigTrafficLightDAL.fetch();
                foreach (Task task in list) {
                    var end = (DateTime)task.dateEnd;
                    var now = DateTime.Now;
                    var date = -(Math.Round((now - end).TotalDays));

                    if (date <= double.Parse(alert.yellow + "")
                        && task.taskStatusId != "2" && task.taskStatusId != "3") {
                        User dUser = new User();
                        if (task.assingId != 0) {
                            var user = UserDAL.fetchAll().Where(x => x.id == task.assingId).FirstOrDefault();
                            if (user != null) {
                                dUser.id = long.Parse(user.id + "");
                                dUser.name = user.name;
                            } else {
                                dUser.name = "Sin Asignar";
                            }
                        } else {
                            dUser.name = "Sin Asignar";
                        }
                        task.creatorUser = dUser;

                        if (task.dateEnd != null) {
                            task.sDateEnd = ((DateTime)task.dateEnd).ToString("dd/MM/yyyy").Replace("-", "/");
                        }


                        newList.Add(task);
                    }
                }
                return newList;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<Task> getTaskGreen(decimal id) {
            try {

                var list = TaskDAL.fetchAllByUnit(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    dateStart = x.date_start,
                    dateEnd = x.date_end,
                    taskStatusId = x.task_status
                }).ToList();

                List<Task> newList = new List<Task>();
                var alert = ConfigTrafficLightDAL.fetch();
                foreach (Task task in list) {
                    var end = (DateTime)task.dateEnd;
                    var now = DateTime.Now;
                    var date = -(Math.Round((now - end).TotalDays));

                    if (date > double.Parse(alert.yellow + "")
                        && task.taskStatusId != "2" && task.taskStatusId != "3") {
                        User dUser = new User();
                        if (task.assingId != 0) {
                            var user = UserDAL.fetchAll().Where(x => x.id == task.assingId).FirstOrDefault();
                            if (user != null) {
                                dUser.id = long.Parse(user.id + "");
                                dUser.name = user.name;
                            } else {
                                dUser.name = "Sin Asignar";
                            }
                        } else {
                            dUser.name = "Sin Asignar";
                        }
                        task.creatorUser = dUser;

                        if (task.dateEnd != null) {
                            task.sDateEnd = ((DateTime)task.dateEnd).ToString("dd/MM/yyyy").Replace("-", "/");
                        }


                        newList.Add(task);
                    }
                }
                return newList;
            } catch (Exception e) {
                throw e;
            }
        }

        public static void refuseTask(decimal id, String message, decimal userId) {
            try {
                TaskDAL.refuseTask(id, message, userId);
            } catch (Exception e) {
                throw e;
            }
        }

        public static void acceptTask(decimal id, decimal userId) {
            try {
                TaskDAL.acceptTask(id, userId);
            } catch (Exception e) {
                throw e;
            }
        }

        public static void assignTask(decimal id, decimal userId) {
            try {
                TaskDAL.assignTask(id, userId);
            } catch (Exception e) {
                throw e;
            }
        }
        public static void editTask(decimal id, String state, decimal userId) {
            try {
                TaskDAL.editTask(id, state, userId);
            } catch (Exception e) {
                throw e;
            }
        }

        public static void createTask(Task task) {
            try {
                if (TaskDAL.exists(task.name)) {
                    throw new ExistsException();
                } else {
                    tasks tasks = new tasks();
                    tasks.name = task.name;
                    tasks.description = task.description;

                    if (task.processId != -1 && task.processId != 0) {
                        tasks.process_id = int.Parse(task.processId + "");
                    }
                    if (task.assingId != -1 && task.processId != 0) {
                        tasks.assing_id = int.Parse(task.assingId + "");
                    }
                    if (task.fatherTaksId != -1 && task.processId != 0) {
                        tasks.father_taks_id = int.Parse(task.fatherTaksId + "");
                    }
                    tasks.task_status = task.taskStatusId;
                    tasks.creator_user_id = task.creatorUserId;
                    tasks.created_at = DateTime.Now;
                    tasks.date_end = task.dateEnd;


                    var id = TaskDAL.createTask(tasks);

                    if (task.document != null) {
                        files file = new files();
                        file.name = task.document.name;
                        file.url = task.document.url;
                        file.path = task.document.path;
                        file.task_id = id;

                        DocumentDAL.createDocument(file);
                    }
                }
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
