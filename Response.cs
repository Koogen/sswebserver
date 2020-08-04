using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Super_Simple_Webserver
{
    public class Response
    {
        private Byte[] data = null;


        private Response(Byte[] data)
        {
            this.data = data;
        }

        public static Response From(Request request)
        {

        }

        public void Post(NetworkStream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(String.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n"));
            stream.Write(data, 0, data.Length);
        }
    }
}
