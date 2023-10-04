using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class MaterialDocument : Cal3dDocument
    {
        public MaterialDocument(string cal3dAssetPath) : base(cal3dAssetPath)
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
