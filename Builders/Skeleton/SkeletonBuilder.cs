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

        public SkeletonBuilder(string serializedName = DefaultSerializedName) : base(serializedName)
        {
            AddHeader(HeaderMagic, HeaderVersion);
            AddRealRoot(RootName);
        }

        public Bone AddBone()
        {

        }
    }
}
