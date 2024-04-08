using DMCal3d.Net.Enums;
using DMCal3d.Net.Exceptions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Unicode;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DMCal3d.Net.Documents
{
    public class Cal3dDocument : ICal3dDocument
    {
        /// <summary>
        /// The name of the document being parsed
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The xml document of the file
        /// </summary>
        public XDocument Document { get; set; }

        public DocumentCasing Casing { get; set; } = DocumentCasing.Unknown;

        public Cal3dDocument(string xml, string name = "")
        {
            Name = name;
            TryParse(xml);
            SetDocumentCasing();
        }

        /// <summary>
        /// Parses the xml data and populates <see cref="Document"/>
        /// </summary>
        /// <param name="xml">The xml data to parse</param>
        /// <exception cref="MalformedAssetException"></exception>
        /// <exception cref="DocumentNullException"></exception>
        private void TryParse(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                try
                {
                    Document = XDocument.Parse(xml);
                }
                catch (XmlException)
                {
                    try
                    {
                        Document = XDocument.Parse("<fakeroot>" + xml + "</fakeroot>");
                    }
                    catch (XmlException)
                    {
                        throw new MalformedAssetException(Name);
                    }
                }
            }

            if (Document == null)
            {
                throw new DocumentNullException(Name);
            }          
        }
        
        /// <summary>
        /// Determines the casing of the xml document
        /// </summary>
        public void SetDocumentCasing()
        {
            XElement? sourceNode = Document.Descendants()
                .FirstOrDefault(x => x.Name.LocalName.IndexOf("header", StringComparison.InvariantCultureIgnoreCase) != -1);

            if (sourceNode != null)
            {
                string headerName = sourceNode.Name.LocalName;

                if (headerName == "HEADER")
                    Casing = DocumentCasing.Uppercase;

                if (headerName == "header")
                    Casing = DocumentCasing.Lowercase;

                if (headerName == "Header")
                    Casing = DocumentCasing.Capitalized;

                return;
            }

            string? templateName = Document.Descendants()?
                .FirstOrDefault(x => x.Name.LocalName.IndexOf("template", StringComparison.InvariantCultureIgnoreCase) != -1)?.Name.LocalName;

            if(!string.IsNullOrEmpty(templateName))
            {
                if (templateName == "TEMPLATE")
                    Casing = DocumentCasing.Uppercase;

                if (templateName == "template")
                    Casing = DocumentCasing.Lowercase;

                if (templateName == "Template")
                    Casing = DocumentCasing.Capitalized;
            }
            
            //todo throw exception
        }

        /// <summary>
        /// Grabs specific elements from the document 
        /// </summary>
        /// <param name="name">The name of the elements we want to return</param>
        /// <param name="matchCase">Case insensitive search flag</param>
        public List<XElement> GetElements(string name, bool matchCase = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<XElement>();
            }

            if (matchCase)
            {
                return Document.Descendants().Where(x => x.Name.LocalName.Equals(name)).ToList();
            }

            return Document.Descendants().Where(x => x.Name.LocalName.Equals(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        /// <summary>
        /// Grabs a specific element from the document 
        /// </summary>
        /// <param name="name">The name of the element we want to return</param>
        /// <param name="matchCase">Case insensitive search flag</param>
        public XElement? GetElement(string name, bool matchCase = false)
        {
            return GetElements(name, matchCase).LastOrDefault();
        }

        public string Save()
        {
            return Document.ConvertToString();
        }

        internal class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
