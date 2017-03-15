
using System;
using GpsLibs.Util;


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
            string time = Datos[0].ToString();
            string nav = Datos[1].ToString();
            gps.Tiempo = "Time of fix "+time.Substring(0,2)+":"+time.Substring(2,2) + ":"+time.Substring(4) + " COT";
            gps.Navegacion = nav.Equals("A") ? "OK" : "WARNING";





            return gps;
        }
    }
}
