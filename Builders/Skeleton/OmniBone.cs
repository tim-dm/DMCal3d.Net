using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Builders.Skeleton
{
    public class OmniBone : Bone
    {
        private const string LightTypeAttributeName = "LIGHTTYPE";
        private const string LightColorAttributeName = "LIGHTCOLOR";

        public void SetLightType(string value)
        {
            SetAttribute(LightTypeAttributeName, value);
        }

        public void SetLightColor(string lightColorR, string lightColorG, string lightColorB)
        {
            SetAttribute(LightColorAttributeName, $"{lightColorR} {lightColorG} {lightColorB}");
        }
    }
}
