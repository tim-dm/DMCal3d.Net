using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Morph
    {
        private const string MorphElementName = "MORPH";
        private const string NameAttributeName = "NAME";
        private const string NumBlendVertsAttributeName = "NUMBLENDVERTS";
        private const string MorphIdAttributeName = "MORPHID";

        public XElement Element { get; private set; }

        public Morph()
        {
            Element = new XElement(MorphElementName, string.Empty);
        }

        public void SetName(string value)
        {
            Element.SetAttributeValue(NameAttributeName, value);
        }

        public void SetBlendVertCount(string value)
        {
            Element.SetAttributeValue(NumBlendVertsAttributeName, value);
        }

        public void SetId(string value)
        {
            Element.SetAttributeValue(MorphIdAttributeName, value);
        }

        public BlendVertex AddBlendVertex(string id = "", string posDiff = "")
        {
            BlendVertex blendVertex = new(id, posDiff);
            Element.Add(blendVertex.Element);
            return blendVertex;
        }
    }
}
