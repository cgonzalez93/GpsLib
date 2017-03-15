
using System;
using GpsLibs.Util;
using System.Diagnostics;

namespace GpsLib
{
    public class Traductor
    {
        public static GpsCore Translate(string trama)
        {
             
            if (string.IsNullOrEmpty(trama)) throw new ArgumentException("Trama es requerida.");

             
            
            GpsCore gps = new GpsCore();
            Convertt.HxToAscii(trama);
            gps.Imei = trama.Substring(0, 12).ToString();
            gps.Evento = trama.Substring(13,4).ToString();
            string AScci = Convertt.HxToAscii(trama.Substring(17).ToString());
            gps.Trama = AScci;
            string[] Datos= AScci.Split(',');
            for (int i = 0; i < Datos.Length; i++)
            {
                Debug.WriteLine("val["+i+"] = "+Datos[i]);
            }
            string time = Datos[0].ToString();
            gps.Tiempo = "Time of fix "+time.Substring(0,2)+":"+time.Substring(2,2) + ":"+time.Substring(4) + " UTC";
            gps.Navegacion = Datos[1].ToString().Equals("A") ? "OK" : "WARNING";
            string lat = Datos[2].ToString();
            string lon = Datos[4].ToString();
            gps.Latitud = "Latitude " + lat.Substring(0, 2) + " deg. " + lat.Substring(3) + " min North";
            gps.Longitud = "Longitude  " + lon.Substring(0, 3) + " deg. " + lon.Substring(4) + " min West";
            gps.Velocidad = Datos[6].ToString();
            gps.Curso = Datos[7].ToString();
            gps.Fecha = Datos[8].ToString();


            return gps;
        }
    }
}
