using System;
using System.IO;
using System.Net;

namespace MyWebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 3)
                {
                    throw new Exception("Incorrect parameters");
                }
                string requestUrl = $"https://localhost:44314/api/values/{args[0]}-{args[1]}-{args[2]}";
                WebRequest request = WebRequest.Create(requestUrl);
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        Console.WriteLine(streamReader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
