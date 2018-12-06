using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_cripto_Explorer
{
    class FileEncDec
    {
        //    public void Encode(string path, string keystring)
        //    {
        //        try
        //        {
        //            using (var myAes = Aes.Create())
        //            {
        //                //считываем из файла
        //                //byte[] original2 = File.ReadAllBytes(path);
        //                byte[] original = File.ReadAllBytes(path);
        //                //char[] original = new char[original2.Length];
        //                //int i = 0;
        //                //foreach (byte number in original2)
        //                //{
        //                //    original[i++] = Convert.ToChar(number);
        //                //    //Console.WriteLine("{0} converts to '{1}'.", number, result);
        //                //}


        //                //читаем пароль
        //                MD5 key = MD5.Create();
        //                myAes.Key = key.ComputeHash(Encoding.UTF8.GetBytes(keystring));

        //                // Зашифрованную строку переводим в массив байтов
        //                byte[] encrypted = EncryptStringToBytesAes(original, myAes.Key, myAes.IV);
        //                File.WriteAllBytes(path+".cript", encrypted);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            // Если что-то не так выбрасываем исключение
        //            Console.WriteLine("Error: {0}", e.Message);
        //            MessageBox.Show(
        //            e.Message,
        //            "Error",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information,
        //            MessageBoxDefaultButton.Button1,
        //            MessageBoxOptions.DefaultDesktopOnly);
        //        }
        //    }

        //    public void Decode(string path,string keystring)
        //    {
        //        try
        //        {
        //            using (var myAes = Aes.Create())
        //            {
        //                //считываем из файла
        //                byte[] original = File.ReadAllBytes(path);
        //                //читаем пароль
        //                MD5 key = MD5.Create();
        //                myAes.Key = key.ComputeHash(Encoding.UTF8.GetBytes(keystring));

        //                // Зашифрованную строку переводим в массив байтов
        //                string decrypted = DecryptStringFromBytesAes(original, myAes.Key, myAes.IV);
        //                File.WriteAllText(path.Remove(path.Length - ".cript".Length), decrypted,Encoding.Default);
        //                //File.WriteAllBytes(path.Remove(path.Length - ".cript".Length), Encoding.Unicode.GetBytes(decrypted) );
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            // Если что-то не так выбрасываем исключение
        //            Console.WriteLine("Error: {0}", e.Message);
        //            MessageBox.Show(   
        //            e.Message,
        //            "Error",             
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information,
        //            MessageBoxDefaultButton.Button1,
        //            MessageBoxOptions.DefaultDesktopOnly);
        //        }
        //    }

        //    static byte[] EncryptStringToBytesAes(byte[] plainText, byte[] Key, byte[] IV)
        //    {
        //        // Проверка аргументов
        //       /* if (plainText == null || plainText.Length <= 0)
        //            throw new ArgumentNullException("plainText");*/
        //        if (Key == null || Key.Length <= 0)
        //            throw new ArgumentNullException("Key");
        //        if (IV == null || IV.Length <= 0)
        //            throw new ArgumentNullException("IV");
        //        byte[] encrypted;

        //        // Создаем объект класса AES
        //        // с определенным ключом and IV.
        //        using (Aes aesAlg = Aes.Create())
        //        {
        //            aesAlg.Key = Key;
        //            aesAlg.IV = IV;

        //            // Создаем объект, который определяет основные операции преобразований.
        //            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //            // Создаем поток для шифрования.
        //            using (var msEncrypt = new MemoryStream())
        //            {
        //                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //                {
        //                    using (var swEncrypt = new StreamWriter(csEncrypt))
        //                    {
        //                        //Записываем в поток все данные.
        //                            swEncrypt.Write(Encoding.UTF8.GetBytes(plainText));


        //                    }
        //                    encrypted = msEncrypt.ToArray();
        //                }
        //            }
        //        }


        //        //Возвращаем зашифрованные байты из потока памяти.
        //        return encrypted;

        //    }

        //    static string DecryptStringFromBytesAes(byte[] cipherText, byte[] Key, byte[] IV)
        //    {
        //        // Проверяем аргументы
        //        if (cipherText == null || cipherText.Length <= 0)
        //            throw new ArgumentNullException("cipherText");
        //        if (Key == null || Key.Length <= 0)
        //            throw new ArgumentNullException("Key");
        //        if (IV == null || IV.Length <= 0)
        //            throw new ArgumentNullException("IV");

        //        // Строка, для хранения расшифрованного текста
        //        //byte[] plaintext;
        //        string plaintext2;
        //        // Создаем объект класса AES,
        //        // Ключ и IV
        //        using (Aes aesAlg = Aes.Create())
        //        {
        //            aesAlg.Key = Key;
        //            aesAlg.IV = IV;

        //            // Создаем объект, который определяет основные операции преобразований.
        //            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        //            // Создаем поток для расшифрования.
        //            using (var msDecrypt = new MemoryStream(cipherText))
        //            {
        //                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //                {
        //                    using (var srDecrypt = new StreamReader(csDecrypt))
        //                    {
        //                        // Читаем расшифрованное сообщение и записываем в строку
        //                        //Encoding temp = new Encoding();
        //                        plaintext2 = srDecrypt.ReadToEnd();

        //                    }
        //                }
        //                //plaintext = msDecrypt.ToArray();
        //                //plaintext2.ToArray();
        //            }

        //        }
        //        return plaintext2;

        //    }
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes
            MemoryStream ms = new MemoryStream();
            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and
            // available on all platforms.
            // You can use other algorithms, to do so substitute the
            // next line with something like
            //      TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();
            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because
            // the algorithm is operating in its default
            // mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 byte)
            // of the data before it is encrypted, and then each
            // encrypted block is XORed with the
            // following block of plaintext.
            // This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure.
            alg.Key = Key;
            alg.IV = IV;
            // Create a CryptoStream through which we are going to be
            // pumping our data.
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream and the output will be written
            // in the MemoryStream we have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            // Write the data and make it do the encryption
            cs.Write(clearData, 0, clearData.Length);
            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our encryption and
            // there is no more data coming in,
            // and it is now a good time to apply the padding and
            // finalize the encryption process.
            cs.Close();
            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way.
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        // Encrypt a string into a string using a password
        //    Uses Encrypt(byte[], byte[], byte[])
        public static string Encrypt(string clearText, string Password)
        {
            // First we need to turn the input string into a byte array.
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(clearText);
            // Then, we need to turn the password into Key and IV
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            // Now get the key/IV and do the encryption using the
            // function that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes.
            byte[] encryptedData = Encrypt(clearBytes,
                     pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting byte array into a string.
            // A common mistake would be to use an Encoding class for that.
            //It does not work because not all byte values can be
            // represented by characters.
            // We are going to be using Base64 encoding that is designed
            //exactly for what we are trying to do.
            return Convert.ToBase64String(encryptedData);
        }

        public static string EncryptToArrayInt(string clearText, string Password)
        {
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(clearText);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] encryptedData = Encrypt(clearBytes,
                     pdb.GetBytes(32), pdb.GetBytes(16));
            string ret = "";
            //нужна строка вида 03 43 56 21 04 00
            foreach (byte b in encryptedData)
            {
               if(b < 100)
                {
                    if(b < 10)
                    {
                        ret += "0";
                    }
                    ret += "0" + Convert.ToInt32(b) + " ";
                }
                    
                else
                    ret += Convert.ToInt32(b) + " ";
            }

            return ret;
        }

        // Encrypt bytes into bytes using a password
        //    Uses Encrypt(byte[], byte[], byte[])
        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the encryption using the function
            // that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8
            // bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes.
            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Encrypt a file into another file using a password
        public static void Encrypt(string fileIn,
                    string fileOut, string Password)
        {
            // First we are going to open the file streams
            FileStream fsIn = new FileStream(fileIn,
                FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut,
                FileMode.OpenOrCreate, FileAccess.Write);
            // Then we are going to derive a Key and an IV from the
            // Password and create an algorithm
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            // Now create a crypto stream through which we are going
            // to be pumping data.
            // Our fileOut is going to be receiving the encrypted bytes.
            CryptoStream cs = new CryptoStream(fsOut,
                alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing
            // the input file in chunks.
            // This is done to avoid reading the whole file (which can
            // be huge) into memory.
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;
            do
            {
                // read a chunk of data from the input file
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                // encrypt it
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
            // close everything
            // this will also close the unrelying fsOut stream
            cs.Close();
            fsIn.Close();
        }

        // Decrypt a byte array into a byte array using a key and an IV
        public static byte[] Decrypt(byte[] cipherData,
                                    byte[] Key, byte[] IV)
        {
            // Create a MemoryStream that is going to accept the
            // decrypted bytes
            MemoryStream ms = new MemoryStream();
            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and
            // available on all platforms.
            // You can use other algorithms, to do so substitute the next
            // line with something like
            //     TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();
            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because the algorithm
            // is operating in its default
            // mode called CBC (Cipher Block Chaining). The IV is XORed with
            // the first block (8 byte)
            // of the data after it is decrypted, and then each decrypted
            // block is XORed with the previous
            // cipher block. This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure.
            alg.Key = Key;
            alg.IV = IV;
            // Create a CryptoStream through which we are going to be
            // pumping our data.
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream
            // and the output will be written in the MemoryStream
            // we have provided.
            CryptoStream cs = new CryptoStream(ms,
                alg.CreateDecryptor(), CryptoStreamMode.Write);
            // Write the data and make it do the decryption
            cs.Write(cipherData, 0, cipherData.Length);
            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our decryption
            // and there is no more data coming in,
            // and it is now a good time to remove the padding
            // and finalize the decryption process.
            cs.Close();
            // Now get the decrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way.
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        // Decrypt a string into a string using a password
        //    Uses Decrypt(byte[], byte[], byte[])
        public static string Decrypt(string cipherText, string Password)
        {
            // First we need to turn the input string into a byte array.
            // We presume that Base64 encoding was used
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            // Then, we need to turn the password into Key and IV
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            // Now get the key/IV and do the decryption using
            // the function that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first
            // getting 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by
            // default 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes.
            byte[] decryptedData = Decrypt(cipherBytes,
               pdb.GetBytes(32), pdb.GetBytes(16));
            // Now we need to turn the resulting byte array into a string.
            // A common mistake would be to use an Encoding class for that.
            // It does not work
            // because not all byte values can be represented by characters.
            // We are going to be using Base64 encoding that is
            // designed exactly for what we are trying to do.
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }


        public static string DecryptArrayInt(string cipherText, string Password)
        {
            //строка представляет 8битное число через пробел типа 00 03 30 44 45 64
            byte[] cipherBytes = new byte[cipherText.Length/4];
            for (int i = 0; i < cipherText.Length; i += 4)
            {
                cipherBytes[i / 4] =  Convert.ToByte( Convert.ToInt32(cipherText.Substring(i, 4).PadLeft(3, '0')));
            }
            //byte[] cipherBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] decryptedData = Decrypt(cipherBytes,
               pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        // Decrypt bytes into bytes using a password
        //    Uses Decrypt(byte[], byte[], byte[])
        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key
            // using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            // Now get the key/IV and do the Decryption using the
            //function that accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV.
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes.
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Decrypt a file into another file using a password
        public static bool Decrypt(string fileIn,
                    string fileOut, string Password)
        {
            FileStream fsIn = null;
            FileStream fsOut = null;
            CryptoStream cs = null;
            try
            {
                // First we are going to open the file streams
                fsIn = new FileStream(fileIn,
                           FileMode.Open, FileAccess.Read);
                fsOut = new FileStream(fileOut,
                           FileMode.OpenOrCreate, FileAccess.Write);
                // Then we are going to derive a Key and an IV from
                // the Password and create an algorithm
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                Rijndael alg = Rijndael.Create();
                alg.Key = pdb.GetBytes(32);
                alg.IV = pdb.GetBytes(16);
                // Now create a crypto stream through which we are going
                // to be pumping data.
                // Our fileOut is going to be receiving the Decrypted bytes.
                cs = new CryptoStream(fsOut,
                   alg.CreateDecryptor(), CryptoStreamMode.Write);
                // Now will will initialize a buffer and will be
                // processing the input file in chunks.
                // This is done to avoid reading the whole file (which can be
                // huge) into memory.
                int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];
                int bytesRead;
                do
                {
                    // read a chunk of data from the input file
                    bytesRead = fsIn.Read(buffer, 0, bufferLen);
                    // Decrypt it
                    cs.Write(buffer, 0, bytesRead);
                } while (bytesRead != 0);
                // close everything
            }
            catch (Exception e)
            {
                // Если что-то не так выбрасываем исключение
                Console.WriteLine("Error: {0}", e.Message);
                MessageBox.Show(
                e.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }
                try
                {
                    if (cs != null)
                        cs.Close(); // this will also close the unrelying fsOut stream
                    if (fsIn != null)
                        fsIn.Close();
                }
                catch (System.Security.Cryptography.CryptographicException eee)
                {
                    //Console.WriteLine("Error: {0}", e.Message);
                    MessageBox.Show(
                    "Password is'n correct",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    cs.Clear();
                    cs.Close();
                    return true;
                }
            
            return false;
        }
            
        }
}

