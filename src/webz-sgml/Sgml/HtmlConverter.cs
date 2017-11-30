using System.IO;
using System.Xml;

using Sgml;
using Webz.Core;

namespace Webz.Sgml
{
    public class HtmlConverter : IHtmlConverter
    {
        private readonly SgmlReader _sgmlReader;

        public HtmlConverter()
        {
            _sgmlReader = new SgmlReader
            {
                DocType = "HTML",
                WhitespaceHandling = WhitespaceHandling.All,
                CaseFolding = CaseFolding.ToLower
            };
        }

        public XmlDocument ToXmlDocument(string html)
        {
            _sgmlReader.InputStream = new StringReader(html);

            var xmlDocument = new XmlDocument
            {
                PreserveWhitespace = true,
                XmlResolver = null
            };

            xmlDocument.Load(_sgmlReader);

            return xmlDocument;
        }
    }
}