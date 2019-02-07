using Newtonsoft.Json;
using System.IO;

namespace dotnet_code_challenge.Helpers
{
    public class JsonParser<T>
    {
        public static T Parse(string path)
        {
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (T)serializer.Deserialize(file, typeof(T));
            }
        }
    }
}
