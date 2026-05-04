using Day_10_coding_SecureApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_10_coding_SecureApp.Services
{
    public class AuthService
    {
        private List<User> users = new List<User>();
        private EncryptionService encryption = new EncryptionService();

        public void Register(string username, string password)
        {
            string hashed = encryption.HashPassword(password);

            users.Add(new User
            {
                Username = username,
                HashedPassword = hashed
            });

            Console.WriteLine("User Registered Successfully");
        }

        public bool Login(string username, string password)
        {
            string hashed = encryption.HashPassword(password);

            var user = users.FirstOrDefault(u => u.Username == username && u.HashedPassword == hashed);

            if (user != null)
            {
                Console.WriteLine("Login Successful");
                return true;
            }

            Console.WriteLine("Invalid Credentials");
            return false;
        }
    }
}
