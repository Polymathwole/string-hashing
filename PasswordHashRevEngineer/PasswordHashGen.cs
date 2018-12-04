using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PasswordHashRevEngineer
{
    class PasswordHashGen
    {
        public static string PasswordHash(string password, string staffid)
        {
            try
            {
                if (password.Trim() == string.Empty)
                {
                    //do not process empty passwords
                    throw new Exception("Custom Error: Cannot process Empty password");
                }
                //create temp for storing and sending hash
                byte[] tempPassword;
                byte[] tempHash;

                tempPassword = Encoding.ASCII.GetBytes(password + staffid);
                HashAlgorithm passwordhash = new MD5CryptoServiceProvider();
                tempHash = passwordhash.ComputeHash(tempPassword);

                //getting the new hashed value

                StringBuilder hashedpassword = new StringBuilder(tempHash.Length);
                for (int i = 0; i <= tempHash.Length - 1; i++)
                {
                    hashedpassword.Append(tempHash[i].ToString("X2"));
                }
                return hashedpassword.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + " from " + ex.TargetSite);
            }
        }

        public string getHash(string clearTextPass, string saltText)
        {

            byte[] kb = Encoding.UTF8.GetBytes(string.Concat(clearTextPass));
            byte[] sb = Encoding.UTF8.GetBytes(string.Concat(saltText));

            byte[] hh = GenerateSaltedHash(kb, sb);

            return Convert.ToBase64String(hh);

        }

        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
