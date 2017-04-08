using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionGUI.Util
{
    class Encryiption
    {
        public static string Encode(string text, string key, int offset = 0)
        {
            while (key.Length < text.Length)
            {
                key += key;
            }

            string encoded = "";
            for (int i = 0; i < text.Length; i++)
            {
                char encodedChar = (char)((int)text[i] + (int)key[i] % 256 + i + offset);
                encoded += encodedChar;
            }

            return encoded;
        }

        public static string Decode(string text, string key, int offset = 0)
        {
            while (key.Length < text.Length)
            {
                key += key;
            }

            string decoded = "";
            for (int i = 0; i < text.Length; i++)
            {
                char decodedChar = (char)((int)text[i] - (int)key[i] % 256 - i - offset);
                decoded += decodedChar;
            }

            return decoded;
        }
    }
}
