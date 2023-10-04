using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class IndexDocument : Cal3dDocument
    {
        private const string MeshIndexTagName = "Index";

        public IndexDocument(string cal3dAssetPath) : base(cal3dAssetPath)
        {

        }

        public List<XElement>? GetBodyPartIds()
        {
            return Document.Element("Template")?.GetChildren("bodypartid[0-9]+");
        }

        public List<XElement>? GetMeshes()
        {
            return Document.Element("Template")?.GetChildren("mesh[0-9]+");
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

        public List<string> GetAllAssetsAsStrings(bool includeDuplicates = false)
        {
            IEnumerable<XElement> collection1 = GetElements("Asset");
            IEnumerable<XElement> collection2 = GetElements("AssetName");

            List<string> values = collection1
                .Concat(collection2)
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .Select(x => x.Value).ToList();

            return includeDuplicates ? values : new HashSet<string>(values).ToList();
        }

        public List<XElement>? GetActions()
        {
            return Document.Element("Template")?.GetChildren("action([0-9].*|$)");
        }

        public XElement? GetLastMesh()
        {
            return GetMeshes()?.LastOrDefault();
        }

        public int GetLargestMeshId()
        {
            return GetMeshes().GetMinMaxTagId("mesh", false);
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
    }
}
