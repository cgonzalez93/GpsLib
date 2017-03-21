using System.Text.RegularExpressions;

namespace GpsLibs.Util
{
   public static class ValidadorExtencion
    {
        public static bool IsBinario(this string valor) {
            string rango = "^[0-1]+$";
            if (Regex.IsMatch(valor, rango))
            {
                return true;
            }
            else {
                return false;
            }
        }
        public static bool IsHexadecimal(this string valor)
        {
            string rango = "^[0-9a-fA-F]+$";
            if (Regex.IsMatch(valor, rango))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsDecimal(this string valor)
        {
            string rango = "^[0-9]+$";
            if (Regex.IsMatch(valor, rango))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
