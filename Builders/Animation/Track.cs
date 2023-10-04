using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Animation
{
    public class Track
    {
        private const string TrackElementName = "TRACK";
        private const string BoneIdAttributeName = "BONEID";
        private const string NumKeyFramesAttributeName = "NUMKEYFRAMES";

        public XElement Element { get; private set; }

        public Track()
        {
            Element = new XElement(TrackElementName, string.Empty);
        }

        public void SetBoneId(object value)
        {
            Element.SetAttributeValue(BoneIdAttributeName, value);
        }

        public void SetNumKeyFrames(object value)
        {
            Element.SetAttributeValue(NumKeyFramesAttributeName, value);
        }

        public KeyFrame AddKeyFrame()
        {
            KeyFrame keyframe = new();
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
