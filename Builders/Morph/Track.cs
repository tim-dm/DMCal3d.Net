using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Morph
{
    public class Track : Node
    {
        private const string TrackElementName = "TRACK";
        private const string NumKeyframesAttributeName = "NUMKEYFRAMES";
        private const string MorphNameAttributeName = "MORPHNAME";

        public Track() : base(TrackElementName) { }

        public void SetNumKeyFrames(string value)
        {
            SetAttribute(NumKeyframesAttributeName, value);
        }

        public void SetMorphName(string value)
        {
            SetAttribute(MorphNameAttributeName, value);
        }

        public KeyFrame AddKeyFrame(string time = "")
        {
            KeyFrame keyframe = new(time);
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
