using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Morph
{
    public class KeyFrame : Node
    {
        private const string KeyframeElementName = "KEYFRAME";
        private const string TimeAttributeName = "TIME";
        private const string WeightName = "WEIGHT";

        public KeyFrame() : base(KeyframeElementName) {}

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
