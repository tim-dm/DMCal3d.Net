﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    public class IndexAction : Node
    {
        private const string DefaultActionElementName = "Action0";

        public IndexAction() : base(DefaultActionElementName) { }

        public IndexAction(string actionId) : base($"Action{actionId}") { }

        public void SetId(string id)
        {
            Element.Name = $"Action{id}";
        }

        public void AddName(string name)
        {
            XElement nameElement = Element.GetChild("name", true) ?? new("Name");
            nameElement.Value = name;
            Element.Add(nameElement);
        }

        public Definition AddDefinition()
        {
            Definition definition = new();
            Element.Add(definition.Element);
            return definition;
        }
    }
}
