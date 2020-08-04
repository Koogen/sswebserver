using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;

namespace Super_Simple_Webserver
{
    public class Response
    {
        private Byte[] data = null;
        private String status, mime;

        private Response(String status, String mime, Byte[] data)
        {
            this.status = status;
            this.data = data;
            this.mime = mime;
        }

        public static Response From(Request request)
        {
            if (request == null)
            {
                return MakeNullRequest();
            }
            
            if (request.Type == "GET")
            {

            } 
            else
            {

            }
        }

        private static Response MakeNullRequest()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fileStream = fileInfo.OpenRead();
            BinaryReader reader = new BinaryReader(fileStream);
            Byte[] d = new byte[fileStream.Length];
            reader.Read(d, 0, d.Length);

            return new Response("400 Bad Request", "html/text", d);
        }

        private static Response MakePageNotFound()
        {
            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "404.html";
            FileInfo fileInfo = new FileInfo(file);
            FileStream fileStream = fileInfo.OpenRead();
            BinaryReader reader = new BinaryReader(fileStream);
            Byte[] d = new byte[fileStream.Length];
            reader.Read(d, 0, d.Length);

            return new Response("404 Page Not Found", "html/text", d);
        }

        public void Post(NetworkStream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(String.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n",
                HTTPServer.VERSION, status, HTTPServer.NAME, mime, data.Length));
            stream.Write(data, 0, data.Length);
        }
    }
}
