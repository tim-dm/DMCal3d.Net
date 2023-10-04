using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Morph
{
    public class KeyFrame
    {
        private const string KeyframeElementName = "KEYFRAME";
        private const string TimeAttributeName = "TIME";
        private const string WeightName = "WEIGHT";

        public XElement Element { get; private set; }

        public KeyFrame(string time = "")
        {
            Element = new(KeyframeElementName, string.Empty);
            SetTime(time);
        }

        public void SetTime(string value)
        {
            Element.SetAttributeValue(TimeAttributeName, value);
        }

        public XElement AddWeight(string value = "1")
        {
            XElement weight = new(WeightName, value);
            Element.Add(weight);
            return weight;
        }
    }
}
