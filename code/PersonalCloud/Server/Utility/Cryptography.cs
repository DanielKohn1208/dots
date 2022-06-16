using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PersonalCloud.Server.Models;
using System.Configuration;
using PersonalCloud.Server;

namespace PersonalCloud.Server.Utility
{
    public static class PasswordCryptography
    {
        public static User Register(string username, string password)
        {
            //generating a salt
            var saltText = GenerateSalt();

            var saltedhashedPassword = SaltAndHashPassword(password, saltText);  

            return new User() 
            {
                UserName = username, 
                Salt = saltText,
                Password = saltedhashedPassword 
            };

        } 

        public static string GenerateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public static bool ValidatePassword(string username, string password)
        {
            using(var db = new PersonalCloudDb())
            {

                var user = db.Users.FirstOrDefault(u => u.UserName == username);
                if(user == null)
                {
                    return false;
                }
                if(user.Password != SaltAndHashPassword(password, user.Salt))
                {
                    return false;
                }
                return true;
            }
        }

        public static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

        }
    }
}