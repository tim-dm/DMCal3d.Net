using DMCal3d.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public interface ICal3dDocument
    {
        /// <summary>
        /// The xml document
        /// </summary>
        public XDocument Document { get; set; }

        /// <summary>
        /// The casing of the elements in the document
        /// </summary>
        public DocumentCasing DocumentCasing { get; set; }
    }
}
