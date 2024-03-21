using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class MaterialDocument : Cal3dDocument
    {
        public MaterialDocument(string cal3dAssetPath, string name = "material.xrf") : base(cal3dAssetPath, name)
        {
        }

        public XElement? GetMaterial()
        {
            return GetElement("material");
        }

        public string? GetTexture()
        {
            return GetMaterial()?
                .GetChildByAttribute("map", "type", "diffuse color", true)?
                .Value ?? "";
        }

        public string? GetOpacity()
        {
            return GetMaterial()?
                .GetChildByAttribute("map", "type", "opacity", true)?
                .Value ?? "";
        }
    }
}
