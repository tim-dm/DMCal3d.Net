using DMCal3d.Net.Builders.Mesh;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Skeleton
{
    public class Bone : Node
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

        public Bone() : base(BoneElementName) { }

        public Bone(string name, int numChilds, int id) : this()
        {
            SetAttribute(NameAttributeName, name);
            SetAttribute(NumChildsAttributeName, numChilds);
            SetAttribute(IdAttributeName, id);
        }

        public void SetName(string value)
        {
            SetAttribute(NameAttributeName, value);
        }

        public void SetNumChilds(int value)
        {
            SetAttribute(NumChildsAttributeName, value);
        }

        public void SetId(int value)
        {
            SetAttribute(IdAttributeName, value);
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