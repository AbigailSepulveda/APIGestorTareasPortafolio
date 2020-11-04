using api_.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_.DAL {
    public class DocumentDAL {

        public DocumentDAL() {
            // default
        }

        public static void createDocument(files file) {
            using (var conn = new db_entities()) {
                try {
                    conn.SP_FILE_INSERT(file.task_id, file.name, file.url, file.path, DateTime.Now);
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        public static List<files> fetchAllByTaskId(long id) {
            using (var conn = new db_entities()) {
                try {
                    return conn.files.Where(x => x.task_id == id).ToList();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
