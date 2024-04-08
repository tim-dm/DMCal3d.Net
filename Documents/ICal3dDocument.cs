using DMCal3d.Net.Enums;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public interface ICal3dDocument
    {
        /// <summary>
        /// The name of the document being parsed
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The xml document
        /// </summary>
        public XDocument Document { get; set; }

        /// <summary>
        /// The casing of the elements in the document
        /// </summary>
        public DocumentCasing Casing { get; set; }
    }
}
