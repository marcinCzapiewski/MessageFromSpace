using System;

namespace MessageFromSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileContent = FileManager.GetFileContent();
            string encryptedFile = Decrypter.Decrypt(fileContent);
            MessagePrinter.Print(encryptedFile);
        }
    }
}
