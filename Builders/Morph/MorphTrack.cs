namespace DMCal3d.Net.Builders.Morph
{
    public class MorphTrack : Node
    {
        private const string TrackElementName = "TRACK";
        private const string NumKeyframesAttributeName = "NUMKEYFRAMES";
        private const string MorphNameAttributeName = "MORPHNAME";

        public MorphTrack() : base(TrackElementName) { }

        public void SetNumKeyFrames(string value)
        {
            SetAttribute(NumKeyframesAttributeName, value);
        }

        public void SetMorphName(string value)
        {
            SetAttribute(MorphNameAttributeName, value);
        }

        public MorphKeyFrame AddKeyFrame(string time = "")
        {
            MorphKeyFrame keyframe = new(time);
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
