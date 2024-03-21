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

        public void SetNumVertices(string value)
        {
            SetAttribute(NumVerticesAttributeName, value);
        }

        public void SetNumFaces(string value)
        {
            SetAttribute(NumFacesAttributeName, value);
        }

        public void SetNumLodSteps(string value)
        {
            SetAttribute(NumLodStepsAttributeName, value);
        }

        public void SetNumSprings(string value)
        {
            SetAttribute(NumSpringsAttributeName, value);
        }

        public void SetNumMorphs(string value)
        {
            SetAttribute(NumMorphsAttributeName, value);
        }

        public void SetNumTexCoords(string value)
        {
            SetAttribute(NumTexCoordsAttributeName, value);
        }

        public void SetMaterial(string value)
        {
            SetAttribute(MaterialAttributeName, value);
        }

        public Vertex AddVertex(string numinfluences = "0", string id = "0")
        {
            Vertex vertex = new();
            vertex.SetNumInfluences(numinfluences);
            vertex.SetId(id);
            Element.Add(vertex.Element);
            return vertex;
        }

        public Morph AddMorph()
        {
            Morph morph = new();
            Element.Add(morph.Element);
            return morph;
        }
    }
}
