

using System.Text;
using System.Xml.Serialization;

namespace Invoices.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string xmlString, string rootName) where T : class
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);
            object? deserializeObject = xmlSerializer.Deserialize(stringReader);

            if (deserializeObject == null || deserializeObject is not T desirializedObjectTypes )
            {
                throw new InvalidOperationException();
            }

            return desirializedObjectTypes;

        }

        public string Serialize<T>(T obj, string rootName) where T : class
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);
            xmlSerializer.Serialize(stringWriter, obj, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
