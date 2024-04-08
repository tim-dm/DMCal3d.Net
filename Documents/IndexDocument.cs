using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class IndexDocument : Cal3dDocument
    {
        private const string MeshIndexTagName = "Index";
        private const string TemplateTagName = "Template";

        public IndexDocument(string xml, string name = "index.xml") : base(xml, name) { }

        public List<XElement>? GetBodyParts()
        {
            return Document.Element(TemplateTagName)?.GetChildren("bodypart[0-9]+");
        }

        public List<XElement>? GetBodyPartIds()
        {
            return Document.Element(TemplateTagName)?.GetChildren("bodypartid", true);
        }

        public List<XElement>? GetMeshes()
        {
            return Document.Element(TemplateTagName)?.GetChildren("mesh[0-9]+");
        }

        public List<XElement>? GetAssets(bool includeDuplicates = false)
        {
            List<XElement> assets = GetElements("Asset");

            if (!includeDuplicates)
            {
                return assets.GroupBy(x => x.Value).Select(s => s.First()).ToList();
            }

            return assets;
        }

        public List<string>? GetAssetValues(bool includeDuplicates = false)
        {
            List<XElement>? assets = GetAssets(includeDuplicates);

            List<string> values = assets
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .Select(x => x.Value).ToList();

            return values;
        }

        public List<XElement>? GetAllAssets(bool includeDuplicates = false)
        {
            IEnumerable<XElement> collection1 = GetElements("Asset");
            IEnumerable<XElement> collection2 = GetElements("AssetName");
            List<XElement> buffer = collection1.Concat(collection2).ToList();           

            if(!includeDuplicates)
            {
                return buffer.GroupBy(x => x.Value).Select(s => s.First()).ToList();
            }

            return buffer;
        }

        public List<string> GetAllAssetValues(bool includeDuplicates = false)
        {
            List<XElement>? assets = GetAllAssets(includeDuplicates);

            List<string> values = assets
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .Select(x => x.Value).ToList();

            return values;
        }

        public List<XElement>? GetActions()
        {
            return Document.Element(TemplateTagName)?.GetChildren("action([0-9].*|$)");
        }

        public XElement? GetLastMesh()
        {
            return GetMeshes()?.LastOrDefault();
        }

        public int GetLargestMeshId()
        {
            return GetMeshes().GetMinMaxTagId("mesh", false);
        }

        public int GetLargestActionId()
        {
            return GetActions().GetMinMaxTagId("action", false);
        }

        public string? GetLargestMeshIndex()
        {
            List<XElement>? meshes = GetMeshes();

            if (meshes == null)
                return null;

            if (meshes.Count == 1)
                return meshes.Last().Element(MeshIndexTagName)?.Value;

            List<int> indexes = new();

            foreach (XElement mesh in meshes)
            {
                XElement? meshIndex = mesh.Element(MeshIndexTagName);

                if (meshIndex == null)
                    continue;

                string meshIndexValue = meshIndex.Value;

                if(string.IsNullOrEmpty(meshIndexValue))
                    continue;

                int index = int.TryParse(meshIndexValue, out index) ? index : -1;

                if (index != -1)
                    indexes.Add(index);
            }

            indexes.Sort();

            return indexes.LastOrDefault().ToString();
        }

        public XElement? GetDataImport()
        {
            return GetElement("__DATAIMPORT");
        }

        public string? GetParentProductId()
        {
            return GetDataImport()?
                .Value
                .Replace("product://", "")
                .Replace("/index.xml", "");
        }

        public void SetParent(string pid)
        {
            XElement? dataImport = GetDataImport();

            if(dataImport != null)
            {
                dataImport.Value = $"product://{pid}/index.xml";
            }
        }

        public string Save()
        {
            StringWriter writer = new Utf8StringWriter();
            Document.Save(writer, SaveOptions.None);
            return writer.ToString();
        }
    }
}
