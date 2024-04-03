using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class MorphDocument : Cal3dDocument
    {
        public MorphDocument(string xml, string name = "morph.xpf") : base(xml, name)
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
