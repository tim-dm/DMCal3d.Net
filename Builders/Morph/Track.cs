using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Morph
{
    public class Track
    {
        private const string TrackElementName = "TRACK";
        private const string NumKeyframesAttributeName = "NUMKEYFRAMES";
        private const string MorphNameAttributeName = "MORPHNAME";

        public XElement Element { get; private set; }

        public Track()
        {
            Element = new(TrackElementName, string.Empty);
        }

        public void SetNumKeyFrames(string value)
        {
            Element.SetAttributeValue(NumKeyframesAttributeName, value);
        }

        public void SetMorphName(string value)
        {
            Element.SetAttributeValue(MorphNameAttributeName, value);
        }

        public KeyFrame AddKeyFrame(string time = "")
        {
            KeyFrame keyframe = new(time);
            Element.Add(keyframe.Element);
            return keyframe;
        }
    }
}
