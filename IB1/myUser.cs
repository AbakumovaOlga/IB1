using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB1
{
    [Serializable]
    public class myUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public bool LimitPassword { get; set; }
        public int LengthPassword { get; set; }

        public static string ADMIN = "ADMIN";


        public myUser(string login)
        {
            Login = login;
            Password = "";
            LimitPassword = true;
        }

        public myUser()
        {
            Password = "";
            LimitPassword = true;
        }

        public bool IsAdmin()
        {
            return (Login == ADMIN);
        }

        public bool IsEmptyPassword()
        {
            return (Password == null || Password == "");
        }
        public void SetNewPassword(string newPassword)
        {
            if (newPassword == null || newPassword == "")
                Password = "";
            else
                Password = Hash(newPassword);
        }

        public bool CheckHashPassword(string newPassword)
        {
            return Hash(newPassword) == Password;
        }

        private static string Hash(string password)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = DigestUtilities.CalculateDigest("MD4", bytes);
            return Hex.ToHexString(hashBytes);
        }

        public bool CheckPassword(string password, int lengthPassword)
        {
            return (password.Length >= lengthPassword);
        }
    }
}
