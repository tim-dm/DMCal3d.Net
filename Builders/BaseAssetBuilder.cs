using DMCal3d.Net.Deserializers;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders
{
    public class BaseAssetBuilder : IAssetBuilder
    {
        private const string HeaderName = "HEADER";
        private const string HeaderMagicAttributeName = "MAGIC";
        private const string HeaderVersionAttributeName = "VERSION"; 
        private const string FakeRootName = "fakeroot";

        /// <summary>
        /// The name used when serializing
        /// </summary>
        public string SerializedName { get; set; }

        /// <summary>
        /// The xml document
        /// </summary>
        public XDocument Document { get; set; } = new();

        /// <summary>
        /// A dummy root element needed to prevent invalid xml 
        /// exceptions caused by cal3d's unique structure
        /// </summary>
        public XElement FakeRoot { get; set; } = new(FakeRootName, string.Empty);

        /// <summary>
        /// The real root element
        /// </summary>
        public XElement RealRoot { get; set; }

        public BaseAssetBuilder(string serializedName = "")
        {
            SerializedName = serializedName;
            Document.Add(FakeRoot);
        }

        public virtual void CreateHeader(string magic, string version)
        {
            XElement header = new(HeaderName);
            header.SetAttributeValue(HeaderMagicAttributeName, magic.ToUpper());
            header.SetAttributeValue(HeaderVersionAttributeName, version.ToUpper());
            FakeRoot.Add(header);
        }

        public virtual void CreateRealRoot(string rootName)
        {
            RealRoot = new(rootName, string.Empty);
            FakeRoot.Add(RealRoot);
        }
    }
}
