using System.Text;
using System.IO;
using System.IO.Compression;
using System.Xml;

ReadToXml();

void WriteToStream() {
    FileInfo fi = new FileInfo(@"E:\test.txt");
    FileStream fs = fi.Create();

    GZipStream gs = new GZipStream(fs, CompressionMode.Compress);

    StreamWriter sw = new StreamWriter(gs, Encoding.UTF8);

    String text = "Hello World ";
    for (int i = 0; i < 1000; i++) {
        sw.WriteLine(text + i);
    }

    sw.Close();
}

void ReadFromStream() {
    FileInfo fi = new FileInfo(@"E:\test.txt");
    FileStream fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.Read);

    GZipStream gs = new GZipStream(fs, CompressionMode.Decompress);

    StreamReader sw = new StreamReader(gs);

    String? line = "";

    do {
        line = sw.ReadLine();
        System.Console.WriteLine(line);
    } while (line != null);
}

void WriteToXml() {
    FileInfo fi = new FileInfo(@"E:\person.xml");
    FileStream fs = fi.Create();

    XmlWriter xw = XmlWriter.Create(fs);
    xw.WriteStartDocument();

    xw.WriteStartElement("person");
    xw.WriteStartElement("first-name");
    xw.WriteValue("Jan");
    xw.WriteEndElement();
    xw.WriteStartElement("last-name");
    xw.WriteValue("de Wit");
    xw.WriteEndElement();
    xw.WriteStartElement("age");
    xw.WriteValue(50);
    xw.WriteEndElement();
    xw.WriteEndElement();

    xw.Close();
}

void ReadToXml() {
    FileInfo fi = new FileInfo(@"E:\person.xml");
    FileStream fs = fi.OpenRead();

    XmlReader xr = XmlReader.Create(fs);
    bool hasPerson = xr.ReadToFollowing("person");
    System.Console.WriteLine($"hasPerson: {hasPerson}");

    XmlReader pr = xr.ReadSubtree();  

    System.Console.WriteLine(pr.ReadInnerXml());

    pr.ReadToFollowing("first-name");
    string firstName = pr.ReadElementContentAsString();
    System.Console.WriteLine(firstName);

    // loopje doen en steeds Read aanroepen
    pr.Read();

    bool hasLastName = pr.ReadToFollowing("last-name");
    System.Console.WriteLine($"hasLastName: {hasLastName}");
    string lastName = pr.ReadElementContentAsString();

    pr.ReadToNextSibling("age");
    int age = pr.ReadElementContentAsInt();

    // System.Console.WriteLine(firstName);
    System.Console.WriteLine(lastName);
    System.Console.WriteLine(age);
}
