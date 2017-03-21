
using System;
using GpsLibs.Util;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GpsLib
{
    public class Traductor
    {
        public static GpsCore Translate(string trama)
        {

            if (string.IsNullOrEmpty(trama)) throw new ArgumentException("Trama es requerida.");



            GpsCore gps = new GpsCore();
            gps.Imei = trama.Substring(0, 12).ToString();
            gps.Evento = trama.Substring(13, 4).ToString();
            string AScci = Convertt.HxToAscii(trama.Substring(17).ToString());
            gps.Trama = AScci;
            string[] Datos = AScci.Split(',');
            for (int i = 0; i < Datos.Length; i++)
            {
                Debug.WriteLine("val[" + i + "] = " + Datos[i]);
            }
            gps.Tiempo = Fecha(Datos[0].ToString()).TimeOfDay.ToString();
            gps.Navegacion = Datos[1].ToString().Equals("A") ? "OK" : "WARNING";
            gps.Latitud = ConvertGradoMinToDecimal(Datos[2].ToString(), Datos[3].ToString());
            gps.Longitud = ConvertGradoMinToDecimal(Datos[4].ToString(), Datos[5].ToString());
            gps.Velocidad = NodosToKmXh(Datos[6].ToString()).ToString();
            gps.Curso = Datos[7].ToString();
            gps.Fecha = Datos[8].ToString();
            return gps;
        }

        public static string ConvertGradoMinToDecimal(string latOrLong,string orientacion)
        {
            bool bLatZero = latOrLong[0].Equals('0');
            double grado = bLatZero ? Convert.ToDouble(latOrLong.Substring(0, 3)) : Convert.ToDouble(latOrLong.Substring(0, 2));
            double min = bLatZero ? Convert.ToDouble(latOrLong.Substring(3).Replace('.',',')) : Convert.ToDouble(latOrLong.Substring(2).Replace('.', ','));
            double val = Math.Round(grado + (min / 60), 7);
            if (orientacion.Equals("W") || orientacion.Equals("S"))val = val * (-1);
            return val.ToString().Replace(',','.');
        }

        public static DateTime Fecha(string fecha)
        {
            double lUFecha = Convert.ToDouble(fecha);
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(lUFecha).ToLocalTime();
        }
        public static double NodosToKmXh(string nudos)
        {
            return (1.852 * Convert.ToDouble(nudos));
        }
        
    }
}
