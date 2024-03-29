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

        public XElement AddActionAttributes(string ensemblePicking, string terminationIterations)
        {
            XElement actionAttributes = new(ActionAttributesElementName);
            Element.Add(actionAttributes);

            actionAttributes.Add(new XElement(ActionEnsemblePickingElementName)
            {
                Value = ensemblePicking
            });

            actionAttributes.Add(new XElement(ActionTerminationIterationsElementName)
            {
                Value = terminationIterations
            });

            return actionAttributes;
        }

        public EnsembleDefinition AddEnsembleDefinition(string id = "")
        {
            EnsembleDefinition ensembleDefinition;
            ensembleDefinition = string.IsNullOrEmpty(id) ? new() : new(id);            
            Element.Add(ensembleDefinition.Element);
            return ensembleDefinition;
        }

        public void AddEnsembleDefinition(EnsembleDefinition ensembleDefinition)
        {
            Element.Add(ensembleDefinition.Element);
        }
    }
}
