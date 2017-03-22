using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLib
{
    public class Events
    {
        private Dictionary<Int32, string> dic;
        public Events() {
            dic = new Dictionary<int, string>();
            dic.Add(9955, "Motor del vehículo encendido");
            dic.Add(0055, "Motor del vehículo apagado");
            dic.Add(0011, "Vehículo en movimiento");
        }

        public string GetEvent(int key) {
            return dic[key];
        }

    }
}
