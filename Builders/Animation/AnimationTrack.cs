using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Animation
{
    public class AnimationTrack : Node
    {
        private const string TrackElementName = "TRACK";
        private const string BoneIdAttributeName = "BONEID";
        private const string NumKeyFramesAttributeName = "NUMKEYFRAMES";

        public AnimationTrack() : base(TrackElementName) { }

        public void SetBoneId(object value)
        {
            SetAttribute(BoneIdAttributeName, value);
        }

        public void SetNumKeyFrames(object value)
        {
            SetAttribute(NumKeyFramesAttributeName, value);
        }

        public AnimationKeyFrame AddKeyFrame()
        {
            AnimationKeyFrame keyframe = new();
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
