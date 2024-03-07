using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
    internal class Security
    {

        public static string Encrypt(string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string encrypted)
        {
            try
            {
                // Trim leading/trailing whitespace
                encrypted = encrypted.Trim();

                var b = Convert.FromBase64String(encrypted);
                var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
            catch (FormatException)
            {
                // Handle the case where decryption failed due to invalid input.
                return "Decryption failed: Invalid Base64 input";
            }
            catch (Exception ex)
            {
                // Handle other exceptions that may occur during decryption.
                return "Decryption failed: " + ex.Message;
            }
        }

        static Aes getAes()
        {
            var keyBytes = new byte[16];
            var skeyBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            Array.Copy(skeyBytes, keyBytes, Math.Min(keyBytes.Length, skeyBytes.Length));

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            return aes;
        }
    }
}
