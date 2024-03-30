using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    public class IndexBuilder : BaseAssetBuilder
    {
        private const string DefaultSerializedName = "index";
        private const string RootName = "Template";
        private const string DataImportElementName = "__DATAIMPORT";

        public IndexBuilder(string serializedName = DefaultSerializedName) : base(serializedName)
        {
            AddHeader();
            CreateRealRoot(RootName);            
        }

        public override void CreateRealRoot(string rootName)
        {
            RealRoot = new(rootName);
            FakeRoot.Add(RealRoot);
        }

        public void AddHeader()
        {
            FakeRoot.Add(new XProcessingInstruction("xml-stylesheet", "version=\"1.0\" encoding=\"UTF-8\""));
        }

        public void AddDataImport(string parentPid)
        {
            XElement dataImport = new(DataImportElementName)
            {
                Value = $"product://{parentPid}/index.xml"
            };
            RealRoot.Add(dataImport);
        }

        public IndexAction AddAction(string id = "")
        {
            IndexAction action;
            action = string.IsNullOrEmpty(id) ? new() : new(id);
            RealRoot.Add(action);
            return action;
        }
    }
}
