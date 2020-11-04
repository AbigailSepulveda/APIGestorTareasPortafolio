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

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Task> fetchAllByUser(decimal id) {
            try {
                return TaskDAL.fetchAllByUser(id).Select(x => new Task {
                    id = long.Parse(x.id + ""),
                    name = x.name
                }).ToList();
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

                    if (task.processId != -1) {
                        tasks.process_id = int.Parse(task.processId + "");
                    }
                    if (task.assingId != -1) {
                        tasks.assing_id = int.Parse(task.assingId + "");
                    }
                    if (task.fatherTaksId != -1) {
                        tasks.father_taks_id = int.Parse(task.fatherTaksId + "");
                    }
                    tasks.task_status = task.taskStatusId;
                    tasks.creator_user_id = task.creatorUserId;
                    tasks.created_at = DateTime.Now;
                    tasks.date_start = DateTime.Parse(task.dateStart);
                    tasks.date_end = DateTime.Parse(task.dateEnd);


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
