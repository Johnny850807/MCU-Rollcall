using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace MCR.utils
{
    public class RijndaelUtils
    { 
        public static string encrypt(string text, byte[] key, byte[] iv)
        {
            byte[] b = encryptStringToBytes(text, key, iv);
            return bytesToString(b);
        }

        public static string decrypt(string encryptedText, byte[] key, byte[] iv)
        {
            byte[] d = stringToBytes(encryptedText);
            return decryptStringFromBytes(d, key, iv);
        }

        public static string bytesToString(byte[] bytes)
        {
            var strb = new StringBuilder();
            for (int i = 0 ;i < bytes.Length; i ++)
            {
                strb.Append(bytes[i]);
                if (i != bytes.Length - 1)
                    strb.Append(' ');
            }
                
            var result = strb.ToString();
            return result;
        }

        public static byte[] stringToBytes(string text)
        {
            string[] split = text.Split(' ');
            byte[] bytes = split.Select(s => Convert.ToByte(s)).ToArray();
            return bytes;
        }

        public static byte[] encryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;
                
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                
                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return encrypted;
        }

        public static string decryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            
            string plaintext = null;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    plaintext = srDecrypt.ReadToEnd();
                }
            }
            return plaintext;
        }
    }
}
