using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Super_Simple_Webserver
{
    public class HTTPServer
    {
        public const String VERSION = "HTTP/1.1";
        public const String NAME = "Super Simple Webserver ver. 1.0";

        private int port;
        private bool running = false;

        private TcpListener listener;

        public HTTPServer(int port)
        {
            this.port = port;
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void StartServer()
        {
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.Start();
        }

        private void Run()
        {

            running = true;
            listener.Start();

            while(running)
            {
                Console.WriteLine("Waiting for connection...");

                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Client Connected!");

                HandleClient(client);

                client.Close();
            }

            //Cleanup
            listener.Stop();
            running = false;

        }

        private void HandleClient(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());

            String message = "";
            while (reader.Peek() != -1) //While there is something to read
            {
                message += reader.ReadLine() + "\n";
            }



            Debug.WriteLine("Request: \n" + message);

            Request request = Request.GetRequest(message);
            Response response = Response.From(request);
            response.Post(client.GetStream());
        }
    }
}
