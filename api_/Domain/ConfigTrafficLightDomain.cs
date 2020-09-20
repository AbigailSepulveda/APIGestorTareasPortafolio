using api_.DAL;
using api_.Models;
using System;

namespace api_.Domain {
    public class ConfigTrafficLightDomain {

        public ConfigTrafficLightDomain() {
            // default
        }

        /**
         * Método para obtener los datos realizando el mapeo desde la capa de datos
         */
        public static ConfigTrafficLight fetch() {
            try {
                var result = ConfigTrafficLightDAL.fetch();
                ConfigTrafficLight entity = new ConfigTrafficLight();
                entity.id = long.Parse(result.id + "");
                entity.green = int.Parse(result.green + "");
                entity.yellow = int.Parse(result.yellow + "");
                entity.red = int.Parse(result.red + "");
                return entity;
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public static void update(long id, int green, int yellow, int red) {
            try {
                ConfigTrafficLightDAL.update(id, green, yellow, red);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
