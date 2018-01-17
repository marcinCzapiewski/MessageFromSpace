using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MessageFromSpace
{
    internal static class FileManager
    {
        public static string GetFileContent()
        {
            string name = ReadFileName();
            string fileContent = ReadFile(name);

            return fileContent;
        }

        private static string ReadFileName()
        {
            string name;
            Console.WriteLine("Podaj pełną ścieżkę z nazwą do pliku: ");
            do
            {
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));

            return name;
        }

        private static string ReadFile(string name)
        {
            try
            {
                using (StreamReader sr = new StreamReader(name))
                {
                    String fileContent = sr.ReadToEnd();
                    return fileContent;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Nie znaleziono pliku o podanej nazwie. " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Nie można otworzyć pliku. " + e.ToString());
            }

            return "";
        }
    }
}
