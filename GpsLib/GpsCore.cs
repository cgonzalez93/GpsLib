using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLib
{
    public class GpsCore
    {

        public string Evento { get; set; }
        public string Imei { get; set; }
        public string Trama { get; set; }
        public string Tiempo { get; set; }
        public string Navegacion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Velocidad { get; set; }
        public string Cursor { get; set; }
        public string Fecha { get; set; }
        public string Variacion { get; set; }
        public string Mandatory { get; set; }
        public GpsCore() {

        }
    }
}
