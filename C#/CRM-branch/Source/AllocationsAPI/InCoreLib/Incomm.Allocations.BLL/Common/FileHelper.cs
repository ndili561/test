using System.IO;
using System.Security.Cryptography;
using System.Text;
using Incomm.Allocations.BLL.Interfaces.VBL;

namespace Incomm.Allocations.BLL.Common
{
   public class FileHelper: IFileHelper
    {
        public byte[] EncryptFileContent(string filePath, string password)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(filePath);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesEncrypted = AES.AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            return bytesEncrypted;
        }
        public byte[] EncryptFileContent(byte[] bytesToBeEncrypted, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesEncrypted = AES.AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            return bytesEncrypted;
        }

        public byte[] DecryptFileContent(string encryptedFilePath, string password)
        {
            byte[] bytesToBeDecrypted = File.ReadAllBytes(encryptedFilePath);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = AES.AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            return bytesDecrypted;
        }

        public byte[] DecryptFileContent(byte[] bytesToBeDecrypted, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = AES.AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            return bytesDecrypted;
        }

        public bool CheckFolderExists(string folderPath)
       {
           return Directory.Exists(folderPath);
       }
        public bool CheckFileExists(string filePath)
        {
            return Directory.Exists(filePath);
        }
    }
}
