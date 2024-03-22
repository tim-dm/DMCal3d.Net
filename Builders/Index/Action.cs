using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    internal class Action : Node
    {
        private const string DefaultActionElementName = "Action0";

        public Action() : base(DefaultActionElementName) { }

        public Action(string actionId) : base($"Action{actionId}") { }
        
        public void SetId(int id)
        {
            SetId(id.ToString());
        }

        public void SetId(string id)
        {
            Element.Name = $"Action{id}";
        }

        public void SetName(string name)
        {
            XElement nameElement = Element.GetChild("name", true) ?? new("Name");
            nameElement.Value = name;
            Element.Add(nameElement);
        }
    }
}
