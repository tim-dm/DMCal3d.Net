﻿using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Vertex : Node
    {
        private const string VertexElementName = "VERTEX";
        private const string NumInfluencesAttributeName = "NUMINFLUENCES";
        private const string IdAttributeName = "ID";

        public Vertex() : base(VertexElementName) { }

        public Vertex(object numInfluences, object id) : this()
        {
            SetAttribute(NumInfluencesAttributeName, numInfluences);
            SetAttribute(IdAttributeName, id);
        }

        public void SetNumInfluences(object value)
        {
            SetAttribute(NumInfluencesAttributeName, value);
        }

        public void SetId(object value)
        {
            SetAttribute(IdAttributeName, value);
        }
    }
}
