using DMCal3d.Net.Enums;
using DMCal3d.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class Cal3dDocument : ICal3dDocument
    {
        public FileInfo AssetInfo { get; set; }

        /// <summary>
        /// The xml document of the file
        /// </summary>
        public XDocument Document { get; set; }

        // <summary>
        /// The casing of the elements in the document
        /// </summary>
        public DocumentCasing DocumentCasing { get; set; } = DocumentCasing.Unknown;

        public Cal3dDocument(string cal3dAssetPath)
        {
            AssetInfo = new(cal3dAssetPath);
            TryParse(File.ReadAllText(AssetInfo.FullName));
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
                        throw new MalformedAssetException(AssetInfo.Name);
                    }
                }
            }

            if (Document == null)
            {
                throw new DocumentNullException(AssetInfo.Name);
            }          
        }
        
        /// <summary>
        /// Determines the casing of the xml document
        /// </summary>
        public void SetDocumentCasing()
        {
            XElement sourceNode = Document.Descendants().FirstOrDefault(x => x.Name.LocalName.IndexOf("header", StringComparison.InvariantCultureIgnoreCase) != -1);

            if (sourceNode != null)
            {
                string headerName = sourceNode.Name.LocalName;

                if (headerName == "HEADER")
                    DocumentCasing = DocumentCasing.Uppercase;

                if (headerName == "header")
                    DocumentCasing = DocumentCasing.Lowercase;

                if (headerName == "Header")
                    DocumentCasing = DocumentCasing.Capitalized;

                return;
            }

            string templateName = Document.Descendants().FirstOrDefault(x => x.Name.LocalName.IndexOf("template", StringComparison.InvariantCultureIgnoreCase) != -1).Name.LocalName;

            if(!string.IsNullOrEmpty(templateName))
            {
                if (templateName == "TEMPLATE")
                    DocumentCasing = DocumentCasing.Uppercase;

                if (templateName == "template")
                    DocumentCasing = DocumentCasing.Lowercase;

                if (templateName == "Template")
                    DocumentCasing = DocumentCasing.Capitalized;
            }            
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
    }
}
