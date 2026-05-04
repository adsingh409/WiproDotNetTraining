using Day_10_coding_SecureApp.Services;

using Day_10_coding_SecureApp.Models;
using System;

var auth = new AuthService();
var encrypt = new EncryptionService();
var logger = new LoggerService();

try
{
    auth.Register("aditya", "1234");

    bool login = auth.Login("aditya", "1234");

    string encrypted = encrypt.Encrypt("Secret Data");
    Console.WriteLine("Encrypted: " + encrypted);

    string decrypted = encrypt.Decrypt(encrypted);
    Console.WriteLine("Decrypted: " + decrypted);

    logger.Log("App ran successfully");
}
catch (Exception ex)
{
    logger.Log("Error: " + ex.Message);
    Console.WriteLine("Error occurred");
}
