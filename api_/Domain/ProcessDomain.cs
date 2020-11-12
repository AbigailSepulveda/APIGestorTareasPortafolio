using api_.DAL;
using api_.DB;
using api_.Models;
using api_.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class ProcessDomain {

        public ProcessDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Process> fetchAllByUnit(decimal id) {
            try {
                List<Process> list = new List<Process>();
                var mProcess = ProcessDAL.fetchAllByUnit(id).ToList();

                foreach (process proceso in mProcess) {
                    var tasks = TaskDAL.fetchByProcess(proceso.id).Count();
                    Process model = new Process();
                    model.id = long.Parse(proceso.id + "");
                    model.name = proceso.name;
                    model.description = proceso.description;
                    model.n_tasks = tasks;
                    list.Add(model);
                }

                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static List<ListProcessResponse> getBackLogByUnit(decimal id) {
            try {
                List<ListProcessResponse> list = new List<ListProcessResponse>();
                var mProcess = ProcessDAL.fetchAllByUnit(id).ToList();

                foreach (process proceso in mProcess) {
                    var dListTasks = TaskDAL.fetchByProcess(proceso.id);
                    ListProcessResponse model = new ListProcessResponse();
                    model.id = long.Parse(proceso.id + "");
                    model.name = proceso.name;
                    model.description = proceso.description;

                    var dTasks = 0;
                    if (dListTasks != null) {
                        model.n_tasks = dListTasks.Count();
                        dTasks = dListTasks.Count();
                    }

                    var pendingTask = 0;
                    var readyTask = 0;
                    if (dListTasks != null) {
                        foreach (tasks tarea in dListTasks) {
                            if (tarea.task_status == "2") {
                                readyTask = readyTask + 1;
                            }
                            if (tarea.task_status == "0" || tarea.task_status == "1" || tarea.task_status == "4") {
                                pendingTask = pendingTask + 1;
                            }
                        }
                    }

                    model.task_peding = pendingTask;
                    model.task_ready = readyTask;


                    var lastTask = TaskDAL.fetchByProcess(proceso.id).OrderByDescending(x => x.date_end).FirstOrDefault();
                    if (lastTask != null) {
                        model.endDate = ((DateTime)lastTask.date_end).ToString("dd/MM/yyyy").Replace("-", "/");
                    }
                    var progress = 0;
                    if (dTasks > 0) {
                        progress = readyTask * 100 / dTasks;
                    }

                    model.progress = progress;
                    list.Add(model);
                }

                return list;
            } catch (Exception e) {
                throw e;
            }
        }

        public static void createProcess(String name, String description, decimal userId) {
            try {
                ProcessDAL.insert(name, description, DateTime.Now, userId);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
