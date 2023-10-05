namespace DMCal3d.Net.Builders.Mesh
{
    public class MeshBuilder : BaseAssetBuilder
    {
        private const string HeaderMagic = "XMF";
        private const string HeaderVersion = "919";
        private const string RootName = "MESH";
        private const string DefaultSerializedName = "mesh";
        private const string NumSubmeshAttributeName = "NUMSUBMESH";

        public MeshBuilder(string serializedName = DefaultSerializedName) : base(serializedName)
        {
            AddHeader(HeaderMagic, HeaderVersion);
            AddRealRoot(RootName);            
        }

        public void SetNumSubMesh(string value)
        {
            RealRoot.SetAttributeValue(NumSubmeshAttributeName, value);
        }

        public Submesh AddSubmesh()
        {
            Submesh submesh = new();
            RealRoot.Add(submesh.Element);
            return submesh;
        }        
    }
}
