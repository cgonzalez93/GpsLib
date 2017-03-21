using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLibs.Util
{
    public class Convertt
    {
        public static string HxToAscii(string hx)
        {
            if (!hx.IsHexadecimal()) throw new ArgumentException("No Es un HExadecimal".ToUpper());
            StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= hx.Length - 2; i += 2)
                {
                    sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hx.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
                }
                return sb.ToString();
        }
        
    }
}
