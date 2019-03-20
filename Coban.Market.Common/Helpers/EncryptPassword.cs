using System;
using System.Security.Cryptography;
using System.Text;

namespace Coban.Market.Common.Helpers
{
    public class EncryptPassword
    {
        public static string Encrypt(string pass)
        {
            MD5CryptoServiceProvider pwd = new MD5CryptoServiceProvider();
            return Decrypt(pass, pwd);
        }

        private static string Decrypt(string pass, HashAlgorithm alg)
        {
            byte[] passByteVal = Encoding.UTF8.GetBytes(pass);
            byte[] passEncypt = alg.ComputeHash(passByteVal);
            return Convert.ToBase64String(passEncypt);
        }
    }
}
