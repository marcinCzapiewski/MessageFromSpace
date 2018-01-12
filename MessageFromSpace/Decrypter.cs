using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageFromSpace
{
    internal static class Decrypter
    {
        private static readonly char[] ToZeroChars =
            { 'a', 'B', 'c', 'D', 'e', 'F', 'g', 'H', 'i', 'J', 'k', 'L', 'm', 'N', 'o', 'P', 'q', 'R', 's', 'T', 'u', 'V', 'w', 'X', 'y', 'Z' };

        public static string Decrypt(string s)
        {
            var sb = new StringBuilder();
            foreach(var c in s)
            {
                sb.Append(ToZeroChars.Contains(c) ? 0 : 1);
            }

            return sb.ToString();
        }
    }
}
