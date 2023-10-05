using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders
{
    public class Node
    {
        public XElement Element { get; private set; }

        public Node(string name)
        {
            Element = new XElement(name, string.Empty);
        }

        public Node AddChild(string name)
        {
            Node node = new(name);
            Element.Add(node);
            return node;
        }
    }
}
