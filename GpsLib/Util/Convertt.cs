using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLibs.Util
{
    public class Convertt
    {
        public static string HEXToASCII(string hexString)

        {
            string ascii = string.Empty;
            string imei = hexString.Substring(0, 12);
            string eventt = hexString.Substring(13, 4);
            string hex = hexString.Substring(17).ToLower();

            string symbols = " !\"#$%&'()*+,-./0123456789:;<=>?@";
            string loAZ = "abcdefghijklmnopqrstuvwxyz";
            symbols += loAZ.ToUpper();
            symbols += "[\\]^_`";
            symbols += loAZ;
            symbols += "{|}~";
            string text = string.Empty;
            int i = 0;

            for (i = 0; i < hex.Length; i += 2)
            {
                var char1 = hex[i];
                if (char1 == ':')
                {
                    i++;
                    char1 = hex[i];
                }
                char char2 = hex[i++];
                int num1 = hex[char1];
                int num2 = hex[char2];
                int value = num1 << 4;
                value = value | num2;

                int valueInt = Convert.ToInt32(value);
                int symbolIndex = valueInt - 32;
                char ch = '?';
                if (symbolIndex >= 0 && value <= 126)
                {
                    ch = symbols[symbolIndex];
                }
                text += ch;
            }
            return text;
            //try
            //{
            //    //string ascii = string.Empty;

            //    for (int i = 0; i < hex.Length; i += 2)
            //    {
            //        String hs = string.Empty;

            //        hs = hexString.Substring(i, 2);
            //        int decval = Convert.ToInt32(hs, 16);
            //        char character = Convert.ToChar(decval);
            //        //Console.WriteLine("val = [{0}] and val2 = [{1}]",character,decval);
            //        ascii += character;

            //    }

            //    return ascii;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //return text;

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

        public static string HxToAscii(string hx)
        {
            if (!hx.IsHexadecimal()) throw new ArgumentException("No Es un Hexadecimal");
            StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= hx.Length - 2; i += 2)
                {
                    sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hx.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
                }
                return sb.ToString();
           
           

        }
    }
}
