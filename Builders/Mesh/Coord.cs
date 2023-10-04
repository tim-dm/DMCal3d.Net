using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Mesh
{
    public class Coord
    {
        private double _x;
        private double _y;
        private double _z;

        public XElement Element { get; private set; }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                SetValue();
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                SetValue();
            }
        }

        public double Z
        {
            get => _z;
            set
            {
                _z = value;
                SetValue();
            }
        }

        public Coord(string name)
        {
            Element = new XElement(name);
        }

        public void SetValue(string value)
        {
            Element.Value = value;
        }

        private void SetValue()
        {
            SetValue($"{_x:0.000} {_y:0.000} {_z:0.000}");
        }
    }
}
