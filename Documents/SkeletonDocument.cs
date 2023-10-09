using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class SkeletonDocument : Cal3dDocument
    {
        public readonly List<string> PoseBoneTypes = new() { "handle", "catcher", "pitcher", "seat", "standing", "sitting" };

        public SkeletonDocument(string cal3dAssetPath, string name = "skeleton.xsf") : base(cal3dAssetPath, name)
        {
        }

        public List<XElement>? GetBones(bool includeRoot = true)
        {
            if (includeRoot)
                return GetElements("bone");
            
            return GetElements("bone")
                .Where(x => x.GetAttribute("name", true).Value.ToLower() != "root")
                .ToList();
        }

        public XElement? GetBone(string attributeName, string attributeValue)
        {
            return GetBones()?
                .Where(x => x.GetAttribute(attributeName).Value.ToLower() == attributeValue.ToLower())
                .FirstOrDefault();
        }

        public bool RemoveBone(string attributeName, string attributeValue)
        {
            XElement? bone = GetBone(attributeName, attributeValue);
            if (bone == null) return false;
            bone.Remove();
            return true;
        }
    
        public List<XElement>? GetPoseBones()
        {
            return GetBones()?
                .Where(x => x.AttributeContains("name", PoseBoneTypes, out string matchedBoneType))
                .ToList();
        }
    }
}
