using System.Security.Cryptography;
using System.Text;

// Assymetric();
Symmetric();

void Assymetric()
{
    string text = "Hello World";

    // Receiver
    RSA alg = RSA.Create();
    string publicKey = alg.ToXmlString(false);
    string privateKey = alg.ToXmlString(true);

    // Sender
    RSA alg2 = RSA.Create();
    alg2.FromXmlString(publicKey);
    byte[] encData = alg2.Encrypt(Encoding.UTF8.GetBytes(text), RSAEncryptionPadding.Pkcs1);

    System.Console.WriteLine(Convert.ToBase64String(encData));

    // Receiver
    RSA alg3 = RSA.Create();
    alg3.FromXmlString(privateKey);
    byte[] data = alg3.Decrypt(encData, RSAEncryptionPadding.Pkcs1);
    System.Console.WriteLine(Encoding.UTF8.GetString(data));
}

void Symmetric()
{
    string text = "Hello World";
    byte[] key;
    byte[] iv;

    // Sender
    Aes alg = Aes.Create();
    // alg.Mode = CipherMode.ECB;
    key = alg.Key;
    iv = alg.IV;

    byte[] crypt;
    using (MemoryStream mem = new MemoryStream())
    {
        using (CryptoStream crypto = new CryptoStream(mem, alg.CreateEncryptor(), CryptoStreamMode.Write))
        using (StreamWriter writer = new StreamWriter(crypto))
        {
            writer.WriteLine(text);
        }

        crypt = mem.ToArray();
    }

    System.Console.WriteLine(Convert.ToBase64String(crypt));


    // Receiver
    Aes alg2 = Aes.Create();
    // alg2.Mode = CipherMode.ECB;
    alg2.Key = key;
    alg2.IV = iv;

    using (MemoryStream mem = new MemoryStream(crypt))
    using (CryptoStream crypto = new CryptoStream(mem, alg2.CreateDecryptor(), CryptoStreamMode.Read))
    using (StreamReader rdr = new StreamReader(crypto))
    {
        string line = rdr.ReadToEnd();
        System.Console.WriteLine(line);
    }
}
