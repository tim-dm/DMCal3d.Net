using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Vertex
    {
        private const string VertexElementName = "VERTEX";
        private const string NumInfluencesAttributeName = "NUMINFLUENCES";
        private const string IdAttributeName = "ID";

        public XElement Element { get; private set; }

        public Vertex()
        {
            Element = new XElement(VertexElementName, string.Empty);
        }

        public void SetNumInfluences(int value)
        {
            Element.SetAttributeValue(NumInfluencesAttributeName, value);
        }

        public void SetId(int value)
        {
            Element.SetAttributeValue(IdAttributeName, value);
        }
    }
}
