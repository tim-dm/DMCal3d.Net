using System.Xml.Linq;

namespace DMCal3d.Net.Deserializers
{
    public interface IAssetBuilder
    {
        /// <summary>
        /// The name used when serializing
        /// </summary>
        public string SerializedName { get; set; }

        /// <summary>
        /// The xml document
        /// </summary>
        public XDocument Document { get; set; }

        /// <summary>
        /// A dummy root element needed to prevent invalid xml 
        /// exceptions caused by cal3d's unique structure
        /// </summary>
        public XElement FakeRoot { get; set; }

        /// <summary>
        /// The real root element
        /// </summary>
        public XElement RealRoot { get; set; }
    }
}
