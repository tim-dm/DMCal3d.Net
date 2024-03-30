namespace DMCal3d.Net.Builders.Animation
{
    public class AnimationTrack : Node
    {
        private const string TrackElementName = "TRACK";
        private const string BoneIdAttributeName = "BONEID";
        private const string NumKeyFramesAttributeName = "NUMKEYFRAMES";

        public AnimationTrack() : base(TrackElementName) { }

        public void SetBoneId(string value)
        {
            SetAttribute(BoneIdAttributeName, value);
        }

        public void SetNumKeyFrames(string value)
        {
            SetAttribute(NumKeyFramesAttributeName, value);
        }

        public AnimationKeyFrame CreateKeyFrame(string time)
        {
            AnimationKeyFrame keyframe = new(time);
            Element.Add(keyframe.Element);
            return keyframe;
        }

        public AnimationKeyFrame CreateKeyFrame()
        {
            AnimationKeyFrame keyframe = new();
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
