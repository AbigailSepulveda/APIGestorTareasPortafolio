using api_.DAL;
using api_.DB;
using api_.Exceptions;
using api_.Models;
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
                    task.assingId = long.Parse(result.assing_id + "");
                    task.description = result.description;
                    task.dateStart = result.date_start;
                    task.dateEnd = result.date_end;
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

        public static void refuseTask(decimal id, String message) {
            try {
                TaskDAL.refuseTask(id,message);
            } catch (Exception e) {
                throw e;
            }
        }

        public static void acceptTask(decimal id) {
            try {
                TaskDAL.acceptTask(id);
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
