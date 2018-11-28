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
    /// <summary>
    /// ResourceController is the default controller, when no controller name is
    /// matched, ResourceController initialized and handles it.
    /// It finds the target resource under /public-resources directory and
    /// respond to the client.
    /// </summary>
    public class ResourceController : RollCallController
    {
        private const string TAG = "ResourceController";
        private const string RESOURCES_DIR = "public-resources\\";
        private string sourceName;
        private static Dictionary<string, byte[]> resourcesCache = new Dictionary<string, byte[]>();

        public static void prepareResources()
        {
            string[] dirNames = Directory.GetDirectories(RESOURCES_DIR);
            Parallel.ForEach(dirNames, d => loadAllFilesUnderDirectoryToCache(d));
            loadAllFilesUnderDirectoryToCache(RESOURCES_DIR);
        }

        private static void loadAllFilesUnderDirectoryToCache(string directory)
        {
            string[] fileNames = Directory.GetFiles(directory);
            Parallel.ForEach(fileNames, fn =>
                resourcesCache[fn] = File.ReadAllBytes(fn));
        }

        public ResourceController(HttpListenerContext client, RollcallServer server) : base(client, server)
        {
            var segments = request.Url.Segments;
            var strb = new StringBuilder();
            for (int i = 1; i < segments.Length; i++)
                strb.Append(segments[i]);
            this.sourceName = strb.ToString();
            if (sourceName.Contains(".html"))
                response.ContentType = "text/html; charset=utf-8";
        }

        

        public override void handleRequest()
        {
            try
            {
                var filePath = RESOURCES_DIR + sourceName;
                if (!resourcesCache.ContainsKey(filePath))
                    resourcesCache[filePath] = File.ReadAllBytes(filePath);
                var bytes = resourcesCache[filePath];
                response.OutputStream.Write(bytes, 0, bytes.Length);
            }
            catch(FileNotFoundException err)
            {
                Log.d(TAG, "Private resource or unexistent resources required: " + sourceName);
                using (Stream stream = client.Response.OutputStream)
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    writer.Write("File not found! Notify the server developer!");
            }
            catch (IOException err)
            {
                Log.err(TAG, "Error while resource I/O executing.", err);
                using (Stream stream = client.Response.OutputStream)
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    writer.Write("File error occurs while parsing the resources required!");
            }
        }
    }
}
