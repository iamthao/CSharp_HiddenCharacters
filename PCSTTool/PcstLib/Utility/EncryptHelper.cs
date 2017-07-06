using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Utility
{
    public static class EncryptHelper
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private static readonly byte[] InitVectorBytes = Encoding.ASCII.GetBytes("6rt1edfi2d8sbx93");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int Keysize = 256;

        public static string Encrypt(string plainText, string passPhrase)
        {
            if (plainText == null) plainText = "";
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, InitVectorBytes))
            {
                byte[] keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, InitVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            if (cipherText == null) cipherText = "";
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, InitVectorBytes))
            {
                byte[] keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, InitVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void EncryptFile(string filePath, string passPhrase)
        {
            FileStream fsInput = new FileStream(filePath,FileMode.Open,FileAccess.Read);
            using (var password = new Rfc2898DeriveBytes(passPhrase, InitVectorBytes))
            {
                // Use the Automatically generated key for Encryption. 
                byte[] keyBytes = password.GetBytes(8);
                using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
                {
                    //symmetricKey.BlockSize = 256;
                    //symmetricKey.Mode = CipherMode.CBC;
                    //symmetricKey.Padding = PaddingMode.PKCS7;

                    DES.Key = keyBytes;
                    DES.IV = keyBytes;
                    using (ICryptoTransform desencrypt = DES.CreateEncryptor())
                    //using (var desencrypt = symmetricKey.CreateEncryptor(keyBytes, keyBytes))
                    {
                        byte[] bytearrayinput = new byte[fsInput.Length];
                        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                        fsInput.Close();
                        CryptoStreamMode mode = CryptoStreamMode.Write;

                        // Set up streams and encrypt
                        MemoryStream memStream = new MemoryStream();
                        CryptoStream cryptoStream = new CryptoStream(memStream, desencrypt, mode);
                        cryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length);
                        cryptoStream.FlushFinalBlock();

                        // Read the encrypted message from the memory stream
                        byte[] encryptedMessageBytes = new byte[memStream.Length];
                        memStream.Position = 0;
                        memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

                        // Encode the encrypted message as base64 string
                        string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);
                        File.WriteAllText(filePath, encryptedMessage);
                    }
                }
            }
        }

    }

}
