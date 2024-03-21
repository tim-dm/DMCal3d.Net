using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class MorphDocument : Cal3dDocument
    {
        public MorphDocument(string cal3dAssetPath, string name = "morph.xpf") : base(cal3dAssetPath, name)
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
