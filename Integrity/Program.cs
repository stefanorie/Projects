using System.Security.Cryptography;
using System.Text;

// SimpleHashing();
// SymmetricHashing();
AsymmetricHashing();


void SimpleHashing()
{
    string text = "Hello World";
    
    SHA1 alg = SHA1.Create();

    byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
    System.Console.WriteLine(Convert.ToBase64String(hash));

    text += ".";

    SHA1 alg2 = SHA1.Create();

    byte[] hash2 = alg2.ComputeHash(Encoding.UTF8.GetBytes(text));
    System.Console.WriteLine(Convert.ToBase64String(hash2));
}


void SymmetricHashing()
{
    string text = "Hello World";
    byte[] key;

    // Sender
    HMACSHA512 alg = new HMACSHA512();
    key = alg.Key;
    byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
    System.Console.WriteLine(Convert.ToBase64String(hash));

    text += "."; // ED

    // Receiver
    HMACSHA512 alg2 = new HMACSHA512();
    alg2.Key = key;
    byte[] hash2 = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
    System.Console.WriteLine(Convert.ToBase64String(hash2));
}


void AsymmetricHashing()
{
    string text = "Hello World";
    string publickKey;

    // Sender
    DSA dsa = DSA.Create();
    publickKey = dsa.ToXmlString(false);
    byte[] signature = dsa.SignData(Encoding.UTF8.GetBytes(text), HashAlgorithmName.SHA1);

    System.Console.WriteLine(publickKey);
    text += ".";

    // Receiver
    DSA dsa2 = DSA.Create();
    dsa2.FromXmlString(publickKey);
    bool isValid = dsa2.VerifyData(Encoding.UTF8.GetBytes(text), signature, HashAlgorithmName.SHA1);

    System.Console.WriteLine(isValid ? "Prima!" : "Is gehackt!");
}