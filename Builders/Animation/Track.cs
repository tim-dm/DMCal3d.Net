using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Animation
{
    public class Track : Node
    {
        private const string TrackElementName = "TRACK";
        private const string BoneIdAttributeName = "BONEID";
        private const string NumKeyFramesAttributeName = "NUMKEYFRAMES";

        public Track() : base(TrackElementName) { }

        public void SetBoneId(object value)
        {
            SetAttribute(BoneIdAttributeName, value);
        }

        public void SetNumKeyFrames(object value)
        {
            SetAttribute(NumKeyFramesAttributeName, value);
        }

        public KeyFrame AddKeyFrame()
        {
            KeyFrame keyframe = new();
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
