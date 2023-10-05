using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Animation
{
    public class KeyFrame : Node
    {
        private const string KeyFrameElementName = "KEYFRAME";
        private const string TimeAttributeName = "TIME";
        private const string TranslationElementName = "TRANSLATION";
        private const string RotationElementName = "ROTATION";

        public KeyFrame() : base(KeyFrameElementName) { }

        public void SetTime(object value)
        {
            SetAttribute(TimeAttributeName, value);
        }

        public XElement AddTranslation(string value = "")
        {
            XElement translation = new(TranslationElementName, value);
            Element.Add(translation);
            return translation;
        }

        public void AddTranslation(XElement translation)
        {
            Element.Add(translation);
        }

        public XElement AddRotation(string value = "")
        {
            XElement rotation = new(RotationElementName, value);
            Element.Add(rotation);
            return rotation;
        }

        public void AddRotation(XElement rotation)
        {
            Element.Add(rotation);
        }
    }
}
