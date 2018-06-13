namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IFileHelper
    {
        byte[] EncryptFileContent(string filePath, string password);
        byte[] EncryptFileContent(byte[] bytesToBeEncrypted, string password);
        byte[] DecryptFileContent(string encryptedFilePath, string password);
        byte[] DecryptFileContent(byte[] bytesToBeDecrypted, string password);
        bool CheckFolderExists(string folderPath);
        bool CheckFileExists(string filePath);
    }
}
