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
                    }).ToList()
                }).ToList();
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
                    }).ToList();

                    TemplateDAL.insert(Template.name, Template.description, list);
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
                TemplateDAL.update(template.id, template.name, template.description, template.state, list);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
