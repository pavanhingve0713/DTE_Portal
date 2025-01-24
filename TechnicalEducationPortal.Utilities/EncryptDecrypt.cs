using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace TechnicalEducationPortal.Utilities
{
    public class EncryptDecrypt
    {
        //public static string Key { get; set; } = ConfigurationManager.AppSettings["key"]!;
        //public static string Encrypt(string value)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Key));
        //        aesAlg.Mode = CipherMode.CFB;
        //        aesAlg.Padding = PaddingMode.PKCS7;

        //        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    swEncrypt.Write(value);
        //                }
        //            }

        //            return Convert.ToBase64String(msEncrypt.ToArray());
        //        }
        //    }
        //}

        //public static string Decrypt(string value)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Key));
        //        aesAlg.Mode = CipherMode.CFB;
        //        aesAlg.Padding = PaddingMode.PKCS7;

        //        byte[] iv = new byte[16];
        //        using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(value)))
        //        {
        //            msDecrypt.Read(iv, 0, iv.Length);

        //            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, iv);

        //            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
        //                {
        //                    return srDecrypt.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
