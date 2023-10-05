using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Submesh : Node
    {
        private const string SubmeshElementName = "SUBMESH";
        private const string NumVerticesAttributeName = "NUMVERTICES";
        private const string NumFacesAttributeName = "NUMFACES";
        private const string NumLodStepsAttributeName = "NUMLODSTEPS";
        private const string NumSpringsAttributeName = "NUMSPRINGS";
        private const string NumMorphsAttributeName = "NUMMORPHS";
        private const string NumTexCoordsAttributeName = "NUMTEXCOORDS";
        private const string MaterialAttributeName = "MATERIAL";

        public Submesh() : base(SubmeshElementName) { }

        public void SetNumVertices(int value)
        {
            SetAttribute(NumVerticesAttributeName, value);
        }

        public void SetNumFaces(int value)
        {
            SetAttribute(NumFacesAttributeName, value);
        }

        public void SetNumLodSteps(int value)
        {
            SetAttribute(NumLodStepsAttributeName, value);
        }

        public void SetNumSprings(int value)
        {
            SetAttribute(NumSpringsAttributeName, value);
        }

        public void SetNumMorphs(int value)
        {
            SetAttribute(NumMorphsAttributeName, value);
        }

        public void SetNumTexCoords(int value)
        {
            SetAttribute(NumTexCoordsAttributeName, value);
        }

        public void SetMaterial(int value)
        {
            SetAttribute(MaterialAttributeName, value);
        }

        public Vertex AddVertex(int numinfluences = 0, int id = 0)
        {
            Vertex vertex = new();
            vertex.SetNumInfluences(numinfluences);
            vertex.SetId(id);
            Element.Add(vertex.Element);
            return vertex;
        }

        public Morph CreateMorph()
        {
            Morph morph = new();
            Element.Add(morph.Element);
            return morph;
        }
    }
}
