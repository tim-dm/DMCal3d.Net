using System.Xml.Linq;

namespace DMCal3d.Net.Documents
{
    public class MeshDocument : Cal3dDocument
    {
        public MeshDocument(string cal3dAssetPath, string name = "mesh.xmf") : base(cal3dAssetPath, name)
        {
        }

        // <summary>
        // Grabs the morphs from a mesh
        // </summary>
        // <returns>A collection of morph nodes</returns>
        public List<XElement> GetMorphs()
        {
            return GetElements("morph", false);
        }

        /// <summary>
        /// Grabs all of the submeshes from a mesh file
        /// </summary>
        /// <returns>A collection of morph nodes</returns>
        public List<XElement> GetSubmeshes()
        {
            return GetElements("submesh", false);
        }

        /// <summary>
        /// Returns a submesh XElement with a matching material
        /// </summary>
        /// <param name="materialId">The material attribute value</param>
        /// <returns>A submesh node</returns>
        public XElement? GetSubmeshByMaterialId(string materialId)
        {
            List<XElement> submeshes = GetSubmeshes();

            foreach (XElement submesh in submeshes)
            {
                XAttribute attribute = submesh.GetAttribute("material", true);

                if (attribute.Value.Equals(materialId))
                {
                    return submesh;
                }
            }

            return null;
        }
    }
}
