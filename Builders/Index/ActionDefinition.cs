using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    public class ActionDefinition : Node
    {
        private const string ActionDefinitionElementName = "ActionDefinition";
        private const string ActionAttributesElementName = "ActionAttributes";

        public ActionDefinition() : base(ActionDefinitionElementName) { }

        public XElement AddActionAttributes()
        {
            XElement actionAttributes = new(ActionAttributesElementName);
            Element.Add(actionAttributes);
            return actionAttributes;
        }
    }
}
