using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gps.Core.Util
{
    public class Convertt
    {
        public static string HEXToASCII(string hexString)

        {
            string ascii = string.Empty;
            try
            {
                //string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = Convert.ToUInt32(hs, 16);
                    char character = Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ascii;

        }



        public static string ASCIIToHex(string ascii)

        {

            StringBuilder sb = new StringBuilder();

            byte[] inputBytes = Encoding.UTF8.GetBytes(ascii);

            foreach (byte b in inputBytes)

            {

                sb.Append(string.Format("{0:x2}", b));

            }

            return sb.ToString();

        }
    }
}
