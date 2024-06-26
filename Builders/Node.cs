﻿using System.Xml.Linq;

namespace DMCal3d.Net.Builders
{
    public class Node
    {
        public XElement Element { get; private set; }

        public Node(string name)
        {
            Element = new XElement(name, string.Empty);
        }

        public Node(string name, string value)
        {
            Element = new XElement(name, value);
        }

        public void SetAttribute(string attributeName, string attributeValue)
        {
            Element.SetAttributeValue(attributeName, attributeValue);
        }

        public void SetValue(string value)
        {
            Element.Value = value;
        }

        public Node CreateChild(string name)
        {
            Node node = new(name);
            Element.Add(node.Element);
            return node;
        }

        public Node CreateChild(string name, string value)
        {
            Node node = new(name, value);
            Element.Add(node.Element);
            return node;
        }
    }
}
