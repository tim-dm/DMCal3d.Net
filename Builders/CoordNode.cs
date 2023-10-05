using System.Xml.Linq;

namespace DMCal3d.Net.Builders
{
    public class CoordNode : Node
    {
        private double? _x;
        private double? _y;
        private double? _z;
        private double? _w;

        public double? X
        {
            get => _x;
            set
            {
                _x = value;
                SetValue();
            }
        }

        public double? Y
        {
            get => _y;
            set
            {
                _y = value;
                SetValue();
            }
        }

        public double? Z
        {
            get => _z;
            set
            {
                _z = value;
                SetValue();
            }
        }

        public double? W
        {
            get => _w;
            set
            {
                _w = value;
                SetValue();
            }
        }

        public CoordNode(string name) : base(name) { }

        private void SetValue()
        {
            SetValue($"{_x:0.000} {_y:0.000} {_z:0.000} {_w:0.000}");
        }
    }
}
