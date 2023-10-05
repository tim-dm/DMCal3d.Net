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

        public Bone(string name, string numChilds, string id) : this()
        {
            SetAttribute(NameAttributeName, name);
            SetAttribute(NumChildsAttributeName, numChilds);
            SetAttribute(IdAttributeName, id);
        }

        public void SetName(string value)
        {
            SetAttribute(NameAttributeName, value);
        }

        public void SetNumChilds(string value)
        {
            SetAttribute(NumChildsAttributeName, value);
        }

        public void SetId(string value)
        {
            SetAttribute(IdAttributeName, value);
        }

        public CoordNode CreateTranslation()
        {
            return CreateCoord(TranslationElementName);
        }

        public CoordNode CreateRotation()
        {
            return CreateCoord(RotationElementName);
        }

        public CoordNode CreateLocalTranslation()
        {
            return CreateCoord(LocalTranslationElementName);
        }

        public CoordNode CreateLocalRotation()
        {
            return CreateCoord(LocalRotationElementName);
        }

        public Node CreateParentId(string value)
        {
            return CreateChild(ParentIdElementName, value.ToString());
        }

        public Node CreateChildId(string value)
        {
            return CreateChild(ChildIdElementName, value.ToString());
        }

        private CoordNode CreateCoord(string name)
        {
            CoordNode coord = new(name);
            Element.Add(coord.Element);
            return coord;
        }

        private CoordNode CreateCoord(string name, string value)
        {
            CoordNode coord = new(name);
            coord.SetValue(value);
            Element.Add(coord.Element);
            return coord;
        }
    }
}