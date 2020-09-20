using api_.DB;
using System;
using System.Linq;

namespace api_.DAL {
    public class ConfigTrafficLightDAL {

        public ConfigTrafficLightDAL() {
            // default
        }

        /**
         * Método para actualizar el registro
         */
        public static void update(long id, int green, int yellow, int red) {
            using (var conn = new db()) {
                try {
                    var entity = conn.config_traffic_lights.Where(x => x.id == id).FirstOrDefault();
                    entity.green = green;
                    entity.yellow = yellow;
                    entity.red = red;
                    entity.updated_at = DateTime.Now;
                    conn.SaveChanges();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        /**
         * Método para devolver lista de los registros
         */
        public static config_traffic_lights fetch() {
            using (var conn = new db()) {
                try {
                    return conn.config_traffic_lights.FirstOrDefault();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}
