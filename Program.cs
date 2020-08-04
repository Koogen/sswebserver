using System;

namespace Super_Simple_Webserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on port 80...");
            HTTPServer server = new HTTPServer(80);
            server.StartServer();
        }
    }
}
