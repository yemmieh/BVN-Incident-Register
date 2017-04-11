using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CoreBVN
{
    public class DataHandlers
    {

        public static XDocument ToXDocument(XElement srcXElement)
        {

            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.Indent = true;

            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
            {
                srcXElement.WriteTo(xmlWriter);
            }
            Console.WriteLine(stringBuilder.ToString());

            XDocument xDocument = XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8a\" ?>" + stringBuilder.ToString());
            return xDocument;
        }
    }
}
