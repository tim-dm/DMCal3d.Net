using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Bone CreateOmniBone(int numChilds, int id)
        {
            Bone omniBone = new();
            omniBone.SetName(OmniBoneNameAttributeValue);
            omniBone.SetId(id);
            omniBone.SetNumChilds(numChilds);
            RealRoot.Add(omniBone.Element);
            return omniBone;
        }

        public Bone CreateBone()
        {
            //temporary
            return null;
        }
    }
}
