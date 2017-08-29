//A.Use ASE encryption to encrypt and decrypt entered string data. Print context of encryption to console:

//Original: Entered data
//Key: 45, B2, F8, AF,81,71,0F, CA, E0,17,52, B0,15,6C, F3, A7, FB,87, EB, DD,1E, D3,51,1A,81,61, D7,4C,9B,7B,5B, C2
//IV: F4, A6, FD,90,4B, EF,8D,6C, A7,65, E5,3B,26,08,9B, B0
//Encrypted: 68, EA, E8,05,7B, F0,09,18,10, E6,69,7B,7C,42,0B, DE

using System;
using System.IO;
using System.Security.Cryptography;
using System.Linq;

namespace Lessons._11.Tasks
{
    public class TaskA
    {
        public static void EncryptSomeText()
        {
            string original = "Entered data";
            SymmetricAlgorithm aes = new AesManaged();
            aes.Key = new byte[] { 0x45, 0xB2, 0xF8, 0xAF, 0x81, 0x71, 0x0F, 0xCA, 0xE0, 0x17, 0x52, 0xB0, 0x15, 0x6C, 0xF3, 0xA7, 0xFB, 0x87, 0xEB, 0xDD, 0x1E, 0xD3, 0x51, 0x1A, 0x81, 0x61, 0xD7, 0x4C, 0x9B, 0x7B, 0x5B, 0xC2 };
            aes.IV = new byte[] { 0xF4, 0xA6, 0xFD, 0x90, 0x4B, 0xEF, 0x8D, 0x6C, 0xA7, 0x65, 0xE5, 0x3B, 0x26, 0x08, 0x9B, 0xB0 };
            using (aes)
            {
                byte[] encrypted = Encrypt(aes, original);
                string roundtrip = Decrypt(aes, encrypted);
                // Displays: My secret data!
                Console.WriteLine("Original: {0}", original);
                Console.Write("Encrypted: ");
                encrypted.ToList().ForEach(x => Console.Write(string.Format("{0:X2} ", x)));
                Console.WriteLine();
                Console.WriteLine("Roundtrip: {0}", roundtrip);
            }
        }

        static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public static void Run()
        {
            EncryptSomeText();
            Waiter.WaitForAnyKey();
        }
    }
}
