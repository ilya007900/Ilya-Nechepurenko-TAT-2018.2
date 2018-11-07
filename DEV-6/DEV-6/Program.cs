using System;
using DEV_6.Json;

namespace DEV_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //if (args.Length != 2)
                //{
                //    throw new ArgumentException("Incorrect parameters");
                //}
                string path = "jFile.json";
                JsonParser jsonParser = new JsonParser(path);
                Json.Json json = jsonParser.Json;
                JsonOutputer jsonOutputer = new JsonOutputer(json);
                jsonOutputer.Output();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
