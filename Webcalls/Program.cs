using System.Xml;

ReadRss();

void ReadRss() {
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://www.nu.nl");

    Stream stream = client.GetStreamAsync("rss").Result;

    XmlReader mainReader = XmlReader.Create(stream);
    mainReader.ReadToFollowing("channel");

    XmlReader channelReader = mainReader.ReadSubtree();

    List<(string, string, string)> result = new List<(string, string, string)>();

    while (channelReader.Read()) {
        if (channelReader.Name.Equals("item") && channelReader.NodeType == XmlNodeType.Element) {
            XmlReader itemReader = channelReader.ReadSubtree();

            while (itemReader.Read()) {
                (string, string, string) entry;
                
                if (itemReader.Name.Equals("title")) {
                    System.Console.WriteLine(itemReader.ReadInnerXml());
                    
                    entry.Item = itemReader.ReadInnerXml();
                }
            }
        }
    }

    // XmlReader itemReader = channelReader.ReadSubtree();
    // itemReader.ReadToDescendant("title");
    // itemReader.Read();

    mainReader.Close();
    channelReader.Close();

    // title, description, category
}
