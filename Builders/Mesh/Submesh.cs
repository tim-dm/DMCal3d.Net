using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Submesh
    {
        private const string SubmeshElementName = "SUBMESH";
        private const string NumVerticesAttributeName = "NUMVERTICES";
        private const string NumFacesAttributeName = "NUMFACES";
        private const string NumLodStepsAttributeName = "NUMLODSTEPS";
        private const string NumSpringsAttributeName = "NUMSPRINGS";
        private const string NumMorphsAttributeName = "NUMMORPHS";
        private const string NumTexCoordsAttributeName = "NUMTEXCOORDS";
        private const string MaterialAttributeName = "MATERIAL";

        public XElement Element { get; private set; }

        public Submesh()
        {
            Element = new XElement(SubmeshElementName, string.Empty);
        }

        public void SetNumVertices(int value)
        {
            Element.SetAttributeValue(NumVerticesAttributeName, value);
        }

        public void SetNumFaces(int value)
        {
            Element.SetAttributeValue(NumFacesAttributeName, value);
        }

        public void SetNumLodSteps(int value)
        {
            Element.SetAttributeValue(NumLodStepsAttributeName, value);
        }

        public void SetNumSprings(int value)
        {
            Element.SetAttributeValue(NumSpringsAttributeName, value);
        }

        public void SetNumMorphs(int value)
        {
            Element.SetAttributeValue(NumMorphsAttributeName, value);
        }

        public void SetNumTexCoords(int value)
        {
            Element.SetAttributeValue(NumTexCoordsAttributeName, value);
        }

        public void SetMaterial(int value)
        {
            Element.SetAttributeValue(MaterialAttributeName, value);
        }

        public Vertex AddVertex(int numinfluences = 0, int id = 0)
        {
            Vertex vertex = new();
            vertex.SetNumInfluences(numinfluences);
            vertex.SetId(id);
            Element.Add(vertex.Element);
            return vertex;
        }
    }
}
