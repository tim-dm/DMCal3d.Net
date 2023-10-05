using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class BlendVertex : Node
    {
        private const string BlendVertexElementName = "BLENDVERTEX";
        private const string VertexIdAttributeName = "VERTEXID";
        private const string PosDiffAttributeName = "POSDIFF";
        private const string PositionElementName = "POSITION";
        private const string NormalElementName = "NORMAL";
        private const string TexCoordElementName = "TEXCOORD";

        public BlendVertex() : base(BlendVertexElementName) { }

        public BlendVertex(string id, string posDiff) : this()
        {
            SetId(id);
            SetposDiff(posDiff);
        }

        public void SetId(string id)
        {
            SetAttribute(VertexIdAttributeName, id);
        }

        public void SetposDiff(string value)
        {
            SetAttribute(PosDiffAttributeName, value);
        }

        public CoordNode AddPosition()
        {
            CoordNode position = new(PositionElementName);
            Element.Add(position.Element);
            return position;
        }

        public CoordNode AddNormal()
        {
            CoordNode position = new(NormalElementName);
            Element.Add(position.Element);
            return position;
        }

        public XElement AddTexCoord(double x = 0, double y = 0)
        {
            XElement texCoord = new(TexCoordElementName)
            {
                Value = $"{x:0.0} {y:0.0}"
            };
            Element.Add(texCoord);
            return texCoord;
        }
    }
}
