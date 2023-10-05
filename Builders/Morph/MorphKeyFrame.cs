using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Morph
{
    public class MorphKeyFrame : Node
    {
        private const string KeyframeElementName = "KEYFRAME";
        private const string TimeAttributeName = "TIME";
        private const string WeightName = "WEIGHT";

        public MorphKeyFrame() : base(KeyframeElementName) {}

        public MorphKeyFrame(string time) : this()
        {
            SetTime(time);
        }

        public void SetTime(string value)
        {
            SetAttribute(TimeAttributeName, value);
        }

        public XElement AddWeight(string value = "1")
        {
            XElement weight = new(WeightName, value);
            Element.Add(weight);
            return weight;
        }
    }
}
