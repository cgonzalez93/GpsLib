using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GpsLibs.Util
{
    public class Convertt
    {
        public static string HxToAscii(string hx)
        {
            if (!hx.IsHexadecimal()) throw new ArgumentException("No Es un Hexadecimal".ToUpper());
            StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= hx.Length - 2; i += 2)
                {
                    sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hx.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
                }
                return sb.ToString();
        }

        public static double ConvertGradoMinToDecimal(string latOrLong, string orientacion)
        {
            bool bLatZero = latOrLong[0].Equals('0');
            double grado = bLatZero ? Convert.ToDouble(latOrLong.Substring(0, 3)) : Convert.ToDouble(latOrLong.Substring(0, 2));
            double min = bLatZero ? Convert.ToDouble(latOrLong.Substring(3).Replace('.', ',')) : Convert.ToDouble(latOrLong.Substring(2).Replace('.', ','));
            double val = Math.Round(grado + (min / 60), 7);
            if (orientacion.Equals("W") || orientacion.Equals("S")) val = val * (-1);
            return val;
        }

        public static string Time(string fecha)
        {            
            return fecha.Substring(0,2) + ":" + fecha.Substring(2, 2) + ":" + fecha.Substring(4,2) ;
        }

        public static string Fecha(string fecha)
        {
            int year = Convert.ToInt32(fecha.Substring(4, 2));
            int mon = Convert.ToInt32(fecha.Substring(2, 2));
            int day = Convert.ToInt32(fecha.Substring(0, 2));
            DateTime date = new DateTime(year, mon, day);
            return date.Day + " " + date.ToString("MMMM") + " " + date.Year;
        }

        public static double NodosToKmXh(string nudos)
        {
            return (1.852 * Convert.ToDouble(nudos));
        }

        public static string Navegacion(string nav){return nav.Equals("A") ? "OK" : "WARNING";}

    }
}
