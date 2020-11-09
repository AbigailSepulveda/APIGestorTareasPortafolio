using api_.DAL;
using api_.DB;
using api_.Exceptions;
using api_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.Domain {
    public class TemplateDomain {

        public TemplateDomain() {
            // default
        }

        /**
         * Método para obtener la lista de datos realizando el mapeo desde la capa de datos
         */
        public static List<Template> fetchAll() {
            try {
                return TemplateDAL.fetchAll().Select(x => new Template {
                    id = long.Parse(x.id + ""),
                    name = x.name,
                    description = x.description,
                    state = int.Parse(x.state + ""),
                    tasks = TemplateTaskDAL.fetchAll().Where(z => z.template_id == x.id).Select(y => new TemplateTask {
                        id = long.Parse(y.id + ""),
                        name = y.name,
                        description = y.description,
                        task_status_code = y.task_status_code,
                        template_id = long.Parse(y.template_id + "")
                    }).ToList(),
                    userId = long.Parse(x.user_id + "")
                }).ToList();
            } catch (Exception e) {
                throw e;
            }
        }
        public static List<Template> fetchAllByUnit(decimal unit_id) {
            try {
                List<Template> list = new List<Template>();

                var mTemplates = TemplateDAL.fetchAllByUnit(unit_id).ToList();

                foreach (templates item in mTemplates) {
                    Template model = new Template();
                    model.id = long.Parse(item.id + "");
                    model.name = item.name;
                    model.description = item.description;
                    model.n_tasks = TemplateTaskDAL.fetchAllByTemplateId(item.id).Count();
                    model.userId = long.Parse(item.user_id + "");
                    list.Add(model);
                }

                return list;

            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public static void insert(Template Template) {
            try {
                if (TemplateDAL.exists(Template.name)) {
                    throw new ExistsException();
                } else {
                    List<templates_tasks> list = Template.tasks.Select(x => new templates_tasks {
                        name = x.name,
                        description = x.description,
                        task_status_code = x.task_status_code,
                        end_date = x.endDate,
                    }).ToList();

                    TemplateDAL.insert(Template.name, Template.description, list, Template.userId);
                }
            } catch (Exception e) {
                throw e;
            }
        }

        public static void start(decimal id, decimal userId) {
            try {

                var template = TemplateDAL.fetchAll().Where(x => x.id == id).FirstOrDefault();
                var tasks = TemplateTaskDAL.fetchAll().Where(x => x.template_id == template.id).ToList();

                decimal processId = ProcessDAL.insert(template.name, template.description, DateTime.Now, userId);

                foreach (templates_tasks ts in tasks) {
                    tasks model = new tasks();
                    model.name = ts.name;
                    model.description = ts.description;
                    model.date_end = ts.end_date;
                    model.task_status = ts.task_status_code;
                    model.creator_user_id = decimal.Parse(userId + "");
                    model.process_id = processId;

                    TaskDAL.createTask(model);
                }


            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(Template template) {
            try {
                List<templates_tasks> list = template.tasks.Select(x => new templates_tasks {
                    name = x.name,
                    description = x.description,
                    task_status_code = x.task_status_code,
                }).ToList();
                TemplateDAL.update(template.id, template.name, template.description, template.state, list, template.userId);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
