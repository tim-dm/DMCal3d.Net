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
        private const string ActionEnsemblePickingElementName = "ActionEnsemblePicking";
        private const string ActionTerminationIterationsElementName = "ActionTerminationIterations";

        public ActionDefinition() : base(ActionDefinitionElementName) { }

        public XElement AddActionAttributes(string ensemblePickingCycle, string terminationIterations)
        {
            XElement actionAttributes = new(ActionAttributesElementName);
            Element.Add(actionAttributes);

            actionAttributes.Add(new XElement(ActionEnsemblePickingElementName)
            {
                Value = ensemblePickingCycle
            });

            actionAttributes.Add(new XElement(ActionTerminationIterationsElementName)
            {
                Value = terminationIterations
            });

            return actionAttributes;
        }

        public EnsembleDefinition AddEnsembleDefinition(string id = "")
        {
            EnsembleDefinition ensembleDefinition = new($"EnsembleDefinition{id}");
            Element.Add(ensembleDefinition);
            return ensembleDefinition;
        }
    }
}
