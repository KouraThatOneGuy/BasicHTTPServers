using System;
using System.IO;
using System.Net;
using System.Text;

class SimpleHttpServer
{
    private HttpListener _listener;

    public SimpleHttpServer(string prefix)
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add(prefix);
    }

    public void Start()
    {
        _listener.Start();
        Console.WriteLine("Server started...");
        while (true)
        {
            var context = _listener.GetContext();
            ProcessRequest(context);
        }
    }

    private void ProcessRequest(HttpListenerContext context)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), context.Request.Url.AbsolutePath.TrimStart('/'));
        if (File.Exists(filePath))
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            context.Response.ContentType = "text/html";
            context.Response.ContentLength64 = fileBytes.Length;
            context.Response.OutputStream.Write(fileBytes, 0, fileBytes.Length);
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            byte[] errorBytes = Encoding.UTF8.GetBytes("<html><body><h1>404 Not Found</h1></body></html>");
            context.Response.OutputStream.Write(errorBytes, 0, errorBytes.Length);
        }
        context.Response.OutputStream.Close();
    }

    public static void Main(string[] args)
    {
        SimpleHttpServer server = new SimpleHttpServer("http://localhost:8080/");
        server.Start();
    }
}
