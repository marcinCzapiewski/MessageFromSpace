using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageFromSpace
{
    internal static class MessagePrinter
    {
        internal static void Print(string binaryMessage)
        {
            Tuple<int, int> borders = CountBorders(binaryMessage);

            char[] message = binaryMessage.ToCharArray();
            int counter = 1;
            foreach (char c in message)
            {
                Console.Write(c == '1' ? "*" : " ");
                if (counter == borders.Item1)
                {
                    Console.WriteLine();
                    counter = 0;
                }
                counter++;
            }
        }

        private static Tuple<int, int> CountBorders(string binaryMessage)
        {
            List<int> dividers = new List<int>();
            FindDividers(binaryMessage, dividers);

            ICollection<Tuple<int, int>> combinations = FindCombinations(dividers);
            Tuple<int, int>[] combinationsArray = new Tuple<int, int>[combinations.Count];
            ReadSizeFromUser(combinations, out IList<Tuple<int, int>> combinationsList, out var chosenCombinationNum);

            return combinationsList[chosenCombinationNum];
        }

        private static void ReadSizeFromUser(ICollection<Tuple<int, int>> combinations, out IList<Tuple<int, int>> combinationsList, out int chosenCombinationNum)
        {
            Console.WriteLine("W jakim rozmiarze chcesz wyświetlić?");

            int counter = 0;
            foreach (var c in combinations)
            {
                Console.WriteLine(counter + ")" + c.Item1 + " * " + c.Item2);
                counter++;
            }

            combinationsList = combinations.ToList();
            ConsoleKeyInfo cki = Console.ReadKey();
            chosenCombinationNum = int.Parse(cki.KeyChar.ToString());

            Console.WriteLine();
        }

        private static ICollection<Tuple<int, int>> FindCombinations(IReadOnlyList<int> dividers)
        {
            ICollection<Tuple<int, int>> combinations = new HashSet<Tuple<int, int>>();

            for (int i = 0, j = dividers.Count - 1; i < dividers.Count; i++, j--)
            {
                if (i == j)
                {
                    continue;
                }

                combinations.Add(new Tuple<int, int>(dividers[i], dividers[j]));
            }

            return combinations;
        }

        private static void FindDividers(string binaryMessage, ICollection<int> dividers)
        {
            for (int i = 2; i <= binaryMessage.Length / 2; i++)
            {
                if (binaryMessage.Length % i == 0)
                {
                    dividers.Add(i);
                }
            }
        }
    }
}
