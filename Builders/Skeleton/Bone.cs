using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Skeleton
{
    public class Bone
    {
        private const string BoneElementName = "SUBMESH";
        private const string NameAttributeName = "NAME";
        private const string NumChildsAttributeName = "NUMCHILDS";
        private const string IdAttributeName = "ID";

        public XElement Element { get; private set; }

        public Bone()
        {
            Element = new XElement(BoneElementName, string.Empty);
        }

        public void SetName(string value)
        {
            Element.SetAttributeValue(NameAttributeName, value);
        }

        public void SetNumChilds(int value)
        {
            Element.SetAttributeValue(NumChildsAttributeName, value);
        }

        public void SetId(int value)
        {
            Element.SetAttributeValue(IdAttributeName, value);
        }
    }
}