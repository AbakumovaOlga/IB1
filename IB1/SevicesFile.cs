using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IB1
{
    public class ServicesFile
    {
        private const string fileName = "myUsers.dat";
        public string passFrase;
        public myUser currentUser;


        public List<myUser> myUsersList = new List<myUser>();

        public void LoadUsersFile()
        {
            if (File.Exists(fileName))
            {
                byte[] encryptedBytes = File.ReadAllBytes(fileName);
                byte[] bytes = DecodingFile(encryptedBytes);
                Console.WriteLine("______________");
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
                Console.WriteLine("______________");
                DeserializeUsers(bytes);
            }
            else
            {
                myUser admin = new myUser(myUser.ADMIN);
                myUsersList.Add(admin);
            }
        }

        private void DeserializeUsers(byte[] bytes)
        {
            XmlSerializer bf = new XmlSerializer(myUsersList.GetType());
            MemoryStream ms = new MemoryStream(bytes);
            myUsersList = (List<myUser>)bf.Deserialize(ms);
        }

        private byte[] DecodingFile(byte[] encryptedBytes)
        {
            DES provider = CreateDES();
            ICryptoTransform transform = provider.CreateDecryptor();

            MemoryStream decryptedStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(decryptedStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            cryptoStream.FlushFinalBlock();
            return decryptedStream.ToArray();
        }

        private DES CreateDES()
        {
            byte[] salt = new byte[] { 134, 77, 21, 3, 83, 52, 16, 117 };
            Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(passFrase, salt, 1000);
            byte[] key = keyGenerator.GetBytes(8);
            byte[] iv = keyGenerator.GetBytes(8);

            // Устанавливаем параметры алгоритма DES
            DES provider = DES.Create();
            provider.Mode = CipherMode.ECB;
            provider.Key = key;
            // Случайное значение
            provider.IV = iv;
            return provider;
        }

        private byte[] EncodingFile(byte[] bytes)
        {
            DES provider = CreateDES();
            ICryptoTransform transform = provider.CreateEncryptor();

            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(encryptedStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            return encryptedStream.ToArray();
        }

        private byte[] SerializeUsers()
        {
            XmlSerializer bf = new XmlSerializer(myUsersList.GetType());
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
            bf.Serialize(sw, myUsersList);
            sw.Flush();
            return ms.ToArray();
        }
        public myUser FindUser(string login)
        {
            return myUsersList.Find(user => user.Login == login);
        }

        public bool IsAdmin()
        {
            return currentUser != null && currentUser.IsAdmin();
        }

        public myUser GetUser(int id)
        {
            return myUsersList[id];
        }

        public void SaveUsersFile()
        {
            byte[] bytes = SerializeUsers();
            Console.WriteLine("--------");
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
            Console.WriteLine("--------");
            byte[] encryptedBytes = EncodingFile(bytes);
            File.WriteAllBytes(fileName, encryptedBytes);
        }
    }
}
