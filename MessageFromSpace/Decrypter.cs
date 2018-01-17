using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageFromSpace
{
    static class Decrypter
    {
        public static int noiseDigitsCounter { get; set; }
        private static char[] ToZeroChars =
            { 'a', 'B', 'c', 'D', 'e', 'F', 'g', 'H', 'i', 'J', 'k', 'L', 'm', 'N', 'o', 'P', 'q', 'R', 's', 'T', 'u', 'V', 'w', 'X', 'y', 'Z' };
        private static char[] ToOneChars =
            { 'A', 'b', 'C', 'd', 'E', 'f', 'G', 'h', 'I', 'j', 'K', 'l', 'M', 'n', 'O', 'p', 'Q', 'r', 'S', 't', 'U', 'v', 'W', 'x', 'Y', 'z' };

        public static string Decrypt(string s)
        {
            noiseDigitsCounter = 0;
            StringBuilder sb = new StringBuilder();

            int separatorPosition = SearchForBlockSeparator(s);
            int messageEndPosition = SearchForMessageEndPosition(separatorPosition, s);

            string properContent = GetRealContent(s, separatorPosition, messageEndPosition);
            int messageLength = GetMessageLength(properContent);

            char[][] encryptedMessage = new char[5][];
            encryptedMessage = FillMessageTab(encryptedMessage, properContent, messageLength);

            int[][] encryptedMessageInts;
            encryptedMessageInts = ConvertToIntsArray(encryptedMessage, messageLength);

            int[] XoredMessage = XorMessage(encryptedMessageInts, messageLength);

            foreach (var x in XoredMessage)
            {
                if(x == 0)
                {
                    sb.Append('0');
                }
                else
                {
                    sb.Append('1');
                }
            }

            Console.WriteLine();

            return sb.ToString();
        }

        private static int[] XorMessage(int[][] encryptedMessageInts, int length)
        {
            int[] xored = new int[length];

            for (int i = 0; i < length; i++)
            {
                xored[i] = encryptedMessageInts[0][i] ^ encryptedMessageInts[1][i] ^ encryptedMessageInts[2][i] ^
                    encryptedMessageInts[3][i] ^ encryptedMessageInts[4][i];
            }

            return xored;
        }

        private static int[][] ConvertToIntsArray(char[][] encryptedMessage, int length)
        {
            int[][] msg = new int[5][];

            for (int i = 0; i < 5; i++)
            {
                msg[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    msg[i][j] = ToZeroChars.Contains(encryptedMessage[i][j]) ? 0 : 1;
                }
            }

            return msg;
        }

        private static char[][] FillMessageTab(char[][] message, string properContent, int messageLength)
        {
            int stringLenght = 0;
            int digitsCounter = 0;
            for (int i = 0; i < 5; i++)
            {
                message[i] = new char[messageLength];
                for (int j = 0; j < messageLength;)
                {
                    if (Char.IsDigit(properContent[stringLenght]))
                    {
                        digitsCounter++;
                        stringLenght++;
                    }
                    else
                    {
                        message[i][j] = properContent[stringLenght];
                        j++;
                        stringLenght++;
                    }
                }
            }

            return message;
        }

        private static int GetMessageLength(string properContent)
        {
            int counter = 0;
            int length = 0;
            for (int i = 0; i < properContent.Length; i++)
            {
                if (Char.IsDigit(properContent[i]))
                {
                    counter++;
                    if (IsFiveDigitsInRow(properContent, i))
                    {
                        length = i - counter;
                        break;
                    }
                }
            }
            return length + 1;
        }

        private static string GetRealContent(string s, int separatorPosition, int messageEndPosition)
        {
            string properContent = "";
            for (int i = separatorPosition; i < messageEndPosition; i++)
            {
                properContent += s[i];
            }

            return properContent;
        }

        private static int SearchForMessageEndPosition(int separatorPosition, string s)
        {
            int messageEndPos = 0;
            int blocksCounter = 1;

            do
            {
                for (int i = separatorPosition; i < s.Length; i++)
                {
                    if (Char.IsDigit(s[i]))
                    {
                        if (IsFiveDigitsInRow(s, i))
                        {
                            i += 5;
                            blocksCounter++;

                            if(blocksCounter == 6)
                            {
                                messageEndPos = i;
                            }
                        }
                    }
                }
            } while (blocksCounter < 6);

            return messageEndPos;
        }

        private static int SearchForBlockSeparator(string s)
        {
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    if (IsFiveDigitsInRow(s, i))
                    {
                        i += 5;
                        break;
                    }
                    else
                    {
                        noiseDigitsCounter++;
                        continue;
                    }
                }
            }

            return i;
        }

        private static bool IsFiveDigitsInRow(string s, int position)
        {
            for (int j = position; j < position + 5; j++)
            {
                if (j >= s.Length)
                    break;
                if (!Char.IsDigit(s[j]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
