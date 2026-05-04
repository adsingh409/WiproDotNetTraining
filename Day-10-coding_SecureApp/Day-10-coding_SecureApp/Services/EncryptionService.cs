using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Day_10_coding_SecureApp.Services
{
    public class EncryptionService
    {
        private readonly string key = "1234567890123456"; // 16 char key

        public string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.GenerateIV();

                using var encryptor = aes.CreateEncryptor();
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(encrypted);
            }
        }

        public string Decrypt(string cipherText)
        {
            var parts = cipherText.Split(':');
            byte[] iv = Convert.FromBase64String(parts[0]);
            byte[] encrypted = Convert.FromBase64String(parts[1]);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                using var decryptor = aes.CreateDecryptor();
                byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }

}
