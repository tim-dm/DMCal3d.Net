using DMCal3d.Net.Builders.Mesh;

namespace DMCal3d.Net.Builders.Skeleton
{
    public class SkeletonBuilder : BaseAssetBuilder
    {
        private const string HeaderMagic = "XSF";
        private const string HeaderVersion = "919";
        private const string RootName = "SKELETON";
        private const string DefaultSerializedName = "skeleton";
        private const string NumBonesAttributeName = "NUMBONES";
        private const string SceneAmbientColorAttributeName = "SCENEAMBIENTCOLOR";
        private const string OmniBoneNameAttributeValue = "Omni01";

        public SkeletonBuilder(string serializedName = DefaultSerializedName) : base(serializedName)
        {
            AddHeader(HeaderMagic, HeaderVersion);
            AddRealRoot(RootName);
        }

        public void SetNumBones(int value)
        {
            RealRoot.SetAttributeValue(NumBonesAttributeName, value);
        }

        public void SetSceneAmbientColor(int rValue, int gValue, int bValue)
        {
            RealRoot.SetAttributeValue(SceneAmbientColorAttributeName, $"{rValue} {gValue} {bValue}");
        }

        //todo: create a method that instantiates a special lighting bone 
        public OmniBone CreateOmniBone(int lightType, int lightColorR, int lightColorG, int lightColorB)
        {
            OmniBone omniBone = new();
            omniBone.SetName(OmniBoneNameAttributeValue);
            omniBone.SetLightType(lightType);
            omniBone.SetLightColor(lightColorR, lightColorG, lightColorB);
            RealRoot.Add(omniBone.Element);
            return omniBone;
        }

        public Bone CreateBone(string name, int numChilds, int id)
        {
            Bone bone = new(name, numChilds, id);
            RealRoot.Add(bone.Element);
            return bone;
        }
    }
}
