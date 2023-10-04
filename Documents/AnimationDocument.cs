using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class AnimationDocument : Cal3dDocument
    {
        public AnimationDocument(string cal3dAssetPath) : base(cal3dAssetPath)
        {
        }

        public List<XElement> GetKeyFrames()
        {
            return GetElements("keyframe");
        }
    }
}
