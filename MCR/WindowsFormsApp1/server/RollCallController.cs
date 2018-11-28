using MCR.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCR.server
{
    public abstract class RollCallController
    {
        public HttpListenerContext client { get; set; }
        protected RollcallServer server;
        protected HttpListenerRequest request;
        protected HttpListenerResponse response;

        public RollCallController(HttpListenerContext client, RollcallServer server)
        {
            this.client = client;
            this.request = client.Request;
            this.response = client.Response;
            this.server = server;
        }

        public abstract void handleRequest();

        public void respond(string content, string contentType = "text/html; charset=utf-8")
        {
            client.Response.ContentType = contentType;
            using (Stream stream = client.Response.OutputStream)
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                writer.Write(content);
        }
    }
}
