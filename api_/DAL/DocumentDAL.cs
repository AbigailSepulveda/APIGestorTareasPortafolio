using api_.DB;
using System;

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
    }
}
