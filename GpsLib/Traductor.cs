
using System;
using GpsLibs.Util;
using System.Diagnostics;

namespace GpsLib
{
    public class Traductor
    {
        public static GpsCore Translate(string trama)
        {

            if (string.IsNullOrEmpty(trama)) throw new ArgumentException("Por Favor Ingrese Una Trama.");
            
            GpsCore gps = new GpsCore();
            gps.Imei = trama.Substring(0, 12).ToString();
            int evento = Convert.ToInt32(trama.Substring(13, 4).ToString());
            gps.Evento = evento + "=>" + new Events().GetEvent(evento);
            if (trama.Substring(17).ToString().Length >= 126)
            { 
                string AScci = Convertt.HxToAscii(trama.Substring(17).ToString());
                gps.Trama = AScci;
                string[] Datos = AScci.Split(',');
                for (int i = 0; i < Datos.Length; i++)
                {
                    Console.WriteLine("val = [{0}] => {1}", i, Datos[i]);
                }
                gps.Tiempo = Convertt.Time(Datos[0]);
                gps.Navegacion = Convertt.Navegacion(Datos[1]);
                gps.Latitud = Convertt.ConvertGradoMinToDecimal(Datos[2], Datos[3]);
                gps.Longitud = Convertt.ConvertGradoMinToDecimal(Datos[4], Datos[5]);
                gps.Velocidad = Convertt.NodosToKmXh(Datos[6]).ToString();
                gps.Cursor = Datos[7].ToString();
                gps.Fecha = Convertt.Fecha(Datos[8]);
                string[] d = Datos[11].Split('*');
                gps.Variacion = Datos[10] + d[0];
                gps.Mandatory = '*'+d[1];
            }
            else {
                throw new Exception("ERROR LA TRAMA DEBE SER SER SUPERIOR A 125");
            }
            
            return gps;
        }

        
        
    }
}
