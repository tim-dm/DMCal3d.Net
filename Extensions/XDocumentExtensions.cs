using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DMCal3d.Net
{
    public static class XDocumentExtensions
    {
        /// <summary>
        /// Converts an XDocument into a string, removing the fake root element added when parsing
        /// </summary>
        /// <param name="document">XDocuemtn to convert</param>
        /// <returns>A string representation of xml</returns>
        public static string ConvertToString(this XDocument document)
        {
            return document.ToString().Replace("<fakeroot>", "")
                .Replace("</fakeroot>", "")
                .Trim();
        }

        /// <summary>
        /// Grabs elements that have no children
        /// </summary>
        /// <param name="document"></param>
        /// <returns>A collection of XElement without children</returns>
        public static List<XElement> GetChildlessElements(this XDocument document)
        {
            return document.Descendants()
                .Where(x => !x.Name.LocalName.Contains("fakeroot", StringComparison.InvariantCultureIgnoreCase) && x.HasElements == false)
                .ToList();
        }
    }
}
