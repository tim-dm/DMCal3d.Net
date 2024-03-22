using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    public class Definition : Node
    {
        private const string DefinitionElementName = "Definition";
        private const string ActionTypeElementName = "ActionType";

        public Definition() : base(DefinitionElementName) { }

        public ActionDefinition AddActionDefinition()
        {
            ActionDefinition actionDefinition = new();
            Element.Add(actionDefinition.Element);
            return actionDefinition;
        }

        public XElement SetActionType(string type)
        {
            XElement ActionType = new(ActionTypeElementName)
            {
                Value = type
            };
            Element.Add(ActionType);
            return ActionType;
        }
    }
}
