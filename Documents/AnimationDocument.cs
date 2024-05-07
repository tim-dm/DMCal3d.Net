using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class AnimationDocument : Cal3dDocument
    {
        public AnimationDocument(string xml) : base(xml)
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

        public List<string> GetTracksAttribute(string attributeName)
        {
            List<string> attributeValues = [];
            
            GetTracks().ForEach(track =>
            {
                XAttribute boneId = track.GetAttribute(attributeName, true);

                if (boneId != null && !string.IsNullOrEmpty(boneId.Value))
                {
                    attributeValues.Add(boneId.Value);
                }
            });

            return attributeValues;
        }
    }
}
