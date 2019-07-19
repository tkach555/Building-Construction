using Building_Construction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Construction
{
    static class Container
    {
        private static Dictionary<string, Object> services = new Dictionary<string, object>();
        private static Dictionary<string, Object> Services {
            get { return services; }
        }
        public static Object GetService(string serviceId) {
            if (!Services.ContainsKey(serviceId)) {
                CreateService(serviceId);
            }
            Object service;
            bool result = Services.TryGetValue(serviceId, out service);
            if (!result) {
                throw new Exception("Неверный id сервиса.");
            }
            return service;
        }

        private static void CreateService(string serviceId) {
            if (serviceId == typeof(WorkersRepository).Name) {
                Services.Add(serviceId, new WorkersRepository());
            }
        }
        private static void SetService(string serviceId, Object service) {
            Services.Add(serviceId, service);
        }
    }
}
