﻿using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Animation
{
    public class AnimationKeyFrame : Node
    {
        private const string KeyFrameElementName = "KEYFRAME";
        private const string TimeAttributeName = "TIME";
        private const string TranslationElementName = "TRANSLATION";
        private const string RotationElementName = "ROTATION";

        public AnimationKeyFrame() : base(KeyFrameElementName) { }

        public AnimationKeyFrame(string time) : this()
        { 
            SetTime(time);
        }

        public void SetTime(string value)
        {
            SetAttribute(TimeAttributeName, value);
        }

        public XElement CreateTranslation(string value = "")
        {
            XElement translation = new(TranslationElementName, value);
            AddTranslation(translation);
            return translation;
        }

        public AnimationKeyFrame AddTranslation(XElement translation)
        {
            Element.Add(translation);
            return this;
        }

        public XElement CreateRotation(string value = "")
        {
            XElement rotation = new(RotationElementName, value);
            AddRotation(rotation);
            return rotation;
        }

        public AnimationKeyFrame AddRotation(XElement rotation)
        {
            Element.Add(rotation);
            return this;
        }
    }
}
