using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AESEncryptionService
{
    private static string key = "some-256-bit-key";

    public static string Encrypt(string plainText)
    {
        var iv = new byte[16];
        byte[] array;

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(plainText);
            }

            array = memoryStream.ToArray();
        }

        return Convert.ToBase64String(array);
    }

    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrWhiteSpace(cipherText))
        {
            throw new ArgumentException("Cipher text cannot be null or whitespace.", nameof(cipherText));
        }

        byte[] buffer;
        try
        {
            buffer = Convert.FromBase64String(cipherText);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Invalid cipher text. The cipher text is not a valid base64 string.", nameof(cipherText));
        }

        var iv = new byte[16];

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key); 
        aes.IV = iv;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(buffer);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        try
        {
            return streamReader.ReadToEnd();
        }
        catch (CryptographicException)
        {
            throw new CryptographicException("Decryption failed. The cipher text may be invalid or corrupted.");
        }
    }
    
}