using DMCal3d.Net.Builders.Mesh;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Skeleton
{
    public class Bone
    {
        private const string BoneElementName = "BONE";
        private const string NameAttributeName = "NAME";
        private const string NumChildsAttributeName = "NUMCHILDS";
        private const string IdAttributeName = "ID";
        private const string TranslationElementName = "TRANSLATION";
        private const string RotationElementName = "ROTATION";
        private const string LocalTranslationElementName = "LOCALTRANSLATION";
        private const string LocalRotationElementName = "LOCALROTATION";
        private const string ParentIdElementName = "PARENTID";
        private const string ChildIdElementName = "CHILDID";

        public XElement Element { get; private set; }

        public Bone()
        {
            Element = new XElement(BoneElementName, string.Empty);
        }

        public Bone(string name, int numChilds, int id) : this()
        {
            SetName(name);
            SetNumChilds(numChilds);
            SetId(id);
        }

        public void SetName(string value)
        {
            Element.SetAttributeValue(NameAttributeName, value);
        }

        public void SetNumChilds(int value)
        {
            Element.SetAttributeValue(NumChildsAttributeName, value);
        }

        public void SetId(int value)
        {
            Element.SetAttributeValue(IdAttributeName, value);
        }

        public Coord CreateTranslation()
        {
            return CreateCoord(TranslationElementName);
        }

        public Coord CreateRotation()
        {
            return CreateCoord(TranslationElementName);
        }

        public Coord CreateLocalTranslation()
        {
            return CreateCoord(RotationElementName);
        }

        public Coord CreateLocalRotation()
        {
            return CreateCoord(LocalTranslationElementName);
        }

        public XElement CreateParentId(int value)
        {
            return CreateChild(ParentIdElementName, value);
        }

        public XElement CreateChildId(int value)
        {
            return CreateChild(ChildIdElementName, value);
        }

        private Coord CreateCoord(string tagName)
        {
            Coord coord = new(LocalRotationElementName);
            Element.Add(coord.Element);
            return coord;
        }

        private XElement CreateChild(string tagName, int value)
        {
            XElement child = new(tagName) { Value = value.ToString() };
            Element.Add(child);
            return child;
        }
    }
}