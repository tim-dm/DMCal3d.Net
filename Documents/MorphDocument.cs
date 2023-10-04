using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class MorphDocument : Cal3dDocument
    {
        public MorphDocument(string cal3dAssetPath) : base(cal3dAssetPath)
        {
        }

        public List<XElement> GetTracks()
        {
            return GetElements("track");
        }

        public List<XElement> GetKeyFrames()
        {
            return GetElements("keyframe");
        }
    }
}
