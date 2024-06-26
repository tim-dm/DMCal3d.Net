﻿namespace DMCal3d.Net.Builders.Skeleton
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
            CreateHeader(HeaderMagic, HeaderVersion);
            CreateRealRoot(RootName);
        }

        public void SetNumBones(int value)
        {
            RealRoot.SetAttributeValue(NumBonesAttributeName, value);
        }

        public void SetSceneAmbientColor(int rValue, int gValue, int bValue)
        {
            RealRoot.SetAttributeValue(SceneAmbientColorAttributeName, $"{rValue} {gValue} {bValue}");
        }

        public OmniBone CreateOmniBone()
        {
            OmniBone omniBone = new();
            omniBone.SetName(OmniBoneNameAttributeValue);
            RealRoot.Add(omniBone.Element);
            return omniBone;
        }

        public OmniBone CreateOmniBone(string lightType, string lightColorR, string lightColorG, string lightColorB)
        {
            OmniBone omniBone = CreateOmniBone();
            omniBone.SetLightType(lightType);
            omniBone.SetLightColor(lightColorR, lightColorG, lightColorB);
            return omniBone;
        }

        public Bone CreateBone(string name, string numChilds, string id)
        {
            Bone bone = new(name, numChilds, id);
            RealRoot.Add(bone.Element);
            return bone;
        }
    }
}
