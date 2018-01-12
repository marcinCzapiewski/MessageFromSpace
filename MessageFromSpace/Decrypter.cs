using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageFromSpace
{
    static class Decrypter
    {
        private static char[] ToZeroChars =
            { 'a', 'B', 'c', 'D', 'e', 'F', 'g', 'H', 'i', 'J', 'k', 'L', 'm', 'N', 'o', 'P', 'q', 'R', 's', 'T', 'u', 'V', 'w', 'X', 'y', 'Z' };
        private static char[] ToOneChars =
            { 'A', 'b', 'C', 'd', 'E', 'f', 'G', 'h', 'I', 'j', 'K', 'l', 'M', 'n', 'O', 'p', 'Q', 'r', 'S', 't', 'U', 'v', 'W', 'x', 'Y', 'z' };

        public static string Decrypt(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var c in s)
            {
                if(ToZeroChars.Contains(c))
                {
                    sb.Append(0);
                }
                else
                {
                    sb.Append(1);
                }
            }

            return sb.ToString();
        }
    }
}
