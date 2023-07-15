using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace verzel_test_api.domain.Settings
{
    public class EncryptDecryptManager
    {
        private readonly static string key = "770A8A65DA156D24EE2A093277530142";

        public static string Encrypt(string text)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cryptoStream))
                        {
                            sw.Write(text);
                        }
                        array = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public static string Decrypt(string text)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(text);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cryptoStream))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
