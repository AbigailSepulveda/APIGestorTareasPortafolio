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
        public ConfigTrafficLight fetch() {
            try {
                var result = ConfigTrafficLightDAL.fetch();
                ConfigTrafficLight entity = new ConfigTrafficLight();
                entity.id = result.id;
                entity.green = result.green;
                entity.yellow = result.yellow;
                entity.red = result.red;
                return entity;
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para crear un nuevo registro
         */
        public void insert(decimal green, decimal yellow, decimal red) {
            try {
                ConfigTrafficLightDAL.insert(green, yellow, red);
            } catch (Exception e) {
                throw e;
            }
        }

        /**
         * Método para actualizar un nuevo registro
         */
        public void update(decimal id, decimal green, decimal yellow, decimal red) {
            try {
                ConfigTrafficLightDAL.update(id, green, yellow, red);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
