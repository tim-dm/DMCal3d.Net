using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class AnimationDocument : Cal3dDocument
    {
        public AnimationDocument(string xml) : base(xml)
        {
        }

        public List<XElement> GetKeyFrames()
        {
            return GetElements("keyframe");
        }
    }
}
