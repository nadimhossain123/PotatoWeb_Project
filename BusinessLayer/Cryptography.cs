using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace BusinessLayer
{
    public class Cryptography
    {
        public static string Encrypt(string toEncrypt)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[toEncrypt.Length];
            encode = Encoding.UTF8.GetBytes(toEncrypt);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public static string Decrypt(string cipherString)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(cipherString);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }


}
