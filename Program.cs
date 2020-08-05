using System;
using System.IO;
using System.Xml;

namespace Super_Simple_Webserver
{
    class Program
    {
        static int port;

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("root/config.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("port");
            port = int.Parse(node.InnerText);
 
            Console.WriteLine("Starting server on port " + port + "...");
            Console.WriteLine(Directory.GetCurrentDirectory());
            HTTPServer server = new HTTPServer(port);
            server.StartServer();
        }
    }
}
