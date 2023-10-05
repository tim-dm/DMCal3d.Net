using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Morph : Node
    {
        private const string MorphElementName = "MORPH";
        private const string NameAttributeName = "NAME";
        private const string NumBlendVertsAttributeName = "NUMBLENDVERTS";
        private const string MorphIdAttributeName = "MORPHID";

        public Morph() : base(MorphElementName) { }

        public Morph(string name, string blendvertCount) : this() 
        {
            SetName(name);
            SetBlendVertCount(blendvertCount);
        }

        public void SetName(string value)
        {
            SetAttribute(NameAttributeName, value);
        }

        public void SetBlendVertCount(string value)
        {
            SetAttribute(NumBlendVertsAttributeName, value);
        }

        public void SetId(string value)
        {
            SetAttribute(MorphIdAttributeName, value);
        }

        public BlendVertex AddBlendVertex(string id = "", string posDiff = "")
        {
            BlendVertex blendVertex = new(id, posDiff);
            Element.Add(blendVertex.Element);
            return blendVertex;
        }
    }
}
