using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace dotnet_code_challenge.Helpers
{
    public class XmlParser<T>
    {
        public static T Parse(string path)
        {
            XElement element = XElement.Load(path);
            StringReader reader = new StringReader(element.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            return (T)xmlSerializer.Deserialize(reader);
        }
    }
}
