using System;
using System.Collections.Generic;
using System.Text;

namespace MessageFromSpace
{
    static class MessagePrinter
    {
        internal static void Print(string binaryMessage)
        {
            Tuple<int, int> borders = CountBorders(binaryMessage);

            char[] message = binaryMessage.ToCharArray();
            int counter = 1;
            int biggerOne = borders.Item1 > borders.Item2 ? borders.Item1 : borders.Item2;
            foreach (char c in message)
            {
                if (c == '1')
                    Console.Write("*");
                else
                    Console.Write(" ");
                if (counter == biggerOne)
                {
                    Console.WriteLine();
                    counter = 0;
                }
                counter++;
            }
        }

        private static Tuple<int, int> CountBorders(string binaryMessage)
        {
            int q = binaryMessage.Length / 2;
            int p = binaryMessage.Length - q;

            bool isPTimesQEqual = false;

            do
            {
                isPTimesQEqual = IsPTimesQEqual(ref q, ref p, binaryMessage);
                break;
            } while (!isPTimesQEqual);

            return new Tuple<int, int>(p, q);
        }

        private static bool IsPTimesQEqual(ref int q, ref int p, string m)
        {
            for (int i = p; i >= 0; i--)
            {
                for (int j = q; j >= 0; j--)
                {
                    if (i * j == m.Length)
                    {
                        if (isPrime(i) && isPrime(j))
                        {
                            p = i;
                            q = j;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static bool isPrime(int num)
        {
            for (int i = 2; i < (int)Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
    }
}
