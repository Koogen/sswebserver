using System;
using System.IO;

namespace Super_Simple_Webserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on port 80...");
            Console.WriteLine(Directory.GetCurrentDirectory());
            HTTPServer server = new HTTPServer(80);
            server.StartServer();
        }
    }
}
